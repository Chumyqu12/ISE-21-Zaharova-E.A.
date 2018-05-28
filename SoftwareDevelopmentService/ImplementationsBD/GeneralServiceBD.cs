using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;
using System.Configuration;
using System.Net.Mail;

namespace SoftwareDevelopmentService.ImplementationsBD
{
	public class GeneralServiceBD : IGeneralService
    {
        private SoftwareDbContext context;

        public GeneralServiceBD(SoftwareDbContext context)
        {
            this.context = context;
        }

        public List<OfferViewModel> GetList()
        {
            List<OfferViewModel> result = context.Offers
                .Select(rec => new OfferViewModel
                {
                    Id = rec.Id,
                    CustomerId = rec.CustomerId,
                    SoftwareId = rec.SoftwareId,
                    DeveloperId = rec.DeveloperId,
                    Creation = SqlFunctions.DateName("dd", rec.Creation) + " " +
                                SqlFunctions.DateName("mm", rec.Creation) + " " +
                                SqlFunctions.DateName("yyyy", rec.Creation),
                    Implementation = rec.Implementation == null ? "" :
                                        SqlFunctions.DateName("dd", rec.Implementation.Value) + " " +
                                        SqlFunctions.DateName("mm", rec.Implementation.Value) + " " +
                                        SqlFunctions.DateName("yyyy", rec.Implementation.Value),
                    Condition = rec.Condition.ToString(),
                    Number = rec.Number,
                    Summa = rec.Summa,
                    CustomerName = rec.Customer.CustomerName,
                    SoftwareName = rec.Software.SoftwareName,
                    DeveloperName = rec.Developer.DeveloperName
                })
                .ToList();
            return result;
        }

        public void CreateOffer(OfferBindingModel model)
        {
            var offer = new Offer
            {
                CustomerId = model.CustomerId,
                SoftwareId = model.SoftwareId,
                Creation = DateTime.Now,
                Number = model.Number,
                Summa = model.Summa,
                Condition = OfferCondition.Принят
            };
            context.Offers.Add(offer);
            context.SaveChanges();

            var customer = context.Customers.FirstOrDefault(x => x.Id == model.CustomerId);
            SendEmail(customer.Mail, "Оповещение по заказам",
            string.Format("Заказ №{0} от {1} создан успешно", offer.Id,
            offer.Creation.ToShortDateString()));
        }

        public void TakeOfferInWork(OfferBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {

                    Offer element = context.Offers.Include(rec => rec.Customer).FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    var SoftwareParts = context.SoftwareParts
                                                .Include(rec => rec.Part)
                                                .Where(rec => rec.SoftwareId == element.SoftwareId);
                    // списываем
                    foreach (var SoftwarePart in SoftwareParts)
                    {
                        int NumberOnWarehouses = SoftwarePart.Number * element.Number;
                        var WarehouseParts = context.WarehouseParts
                                                    .Where(rec => rec.PartId == SoftwarePart.PartId);
                        foreach (var WarehousePart in WarehouseParts)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (WarehousePart.Number >= NumberOnWarehouses)
                            {
                                WarehousePart.Number -= NumberOnWarehouses;
                                NumberOnWarehouses = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                NumberOnWarehouses -= WarehousePart.Number;
                                WarehousePart.Number = 0;
                                context.SaveChanges();
                            }
                        }
                        if (NumberOnWarehouses > 0)
                        {
                            throw new Exception("Не достаточно компонента " +
                                SoftwarePart.Part.PartName + " требуется " +
                                SoftwarePart.Number + ", не хватает " + NumberOnWarehouses);
                        }
                    }
                    element.DeveloperId = model.DeveloperId;
                    element.Implementation = DateTime.Now;
                    element.Condition = OfferCondition.Выполняется;
                    context.SaveChanges();
                    SendEmail(element.Customer.Mail, "Оповещение по заказам",
                    string.Format("Заказ №{0} от {1} передеан в работу", element.Id, element.Creation.ToShortDateString()));
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void FinalOffer(int id)
        {
            Offer element = context.Offers.Include(rec => rec.Customer).FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Condition = OfferCondition.Готов;
            context.SaveChanges();
            SendEmail(element.Customer.Mail, "Оповещение по заказам",
            string.Format("Заказ №{0} от {1} передан на оплату", element.Id,
            element.Creation.ToShortDateString()));
        }

        public void CostOffer(int id)
        {
            Offer element = context.Offers.Include(rec => rec.Customer).FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.Condition = OfferCondition.Оплачен;
            context.SaveChanges();
            SendEmail(element.Customer.Mail, "Оповещение по заказам",
            string.Format("Заказ №{0} от {1} оплачен успешно", element.Id, element.Creation.ToShortDateString()));
        }

        public void PutPartOnWarehouse(WarehousePartBindingModel model)
        {
            WarehousePart element = context.WarehouseParts
                                                .FirstOrDefault(rec => rec.WarehouseId == model.WarehouseId &&
                                                                    rec.PartId == model.PartId);
            if (element != null)
            {
                element.Number += model.Number;
            }
            else
            {
                context.WarehouseParts.Add(new WarehousePart
                {
                    WarehouseId = model.WarehouseId,
                    PartId = model.PartId,
                    Number = model.Number
                });
            }
            context.SaveChanges();
        }

        private void SendEmail(string mailAddress, string subject, string text)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = null;

            try
            {
                objMailMessage.From = new MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;
                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;

                objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailLogin"],
                    ConfigurationManager.AppSettings["MailPassword"]);

                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMailMessage = null;
                objSmtpClient = null;
            }
        }

    }
}
