using SoftwareDevelopmentModel;
using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDevelopmentService.ImplementationsBD
{
   public class CustomerServiceBD: ICustomerService
    {
        private SoftwareDbContext context;

        public CustomerServiceBD(SoftwareDbContext context)
        {
            this.context = context;
        }

        public List<CustomerViewModel> GetList()
        {
            List<CustomerViewModel> result = context.Customers
                .Select(rec => new CustomerViewModel
                {
                    Id = rec.Id,
                    CustomerName = rec.CustomerName,
                    Mail = rec.Mail
                })
                .ToList();
            return result;
        }

        public CustomerViewModel GetElement(int id)
        {
            Customer element = context.Customers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new CustomerViewModel
                {
                    Id = element.Id,
                    CustomerName = element.CustomerName,
                    Mail = element.Mail,
                    Messages = context.MessageInfos
                            .Where(recM => recM.CustomerId == element.Id)
                            .Select(recM => new MessageInfoViewModel
                           {
                        MessageId = recM.MessageId,
                        DateDelivery = recM.DateDelivery,
                        Subject = recM.Subject,
                        Body = recM.Body
                            })
                           .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CustomerBindingModel model)
        {
            Customer element = context.Customers.FirstOrDefault(rec => rec.CustomerName == model.CustomerName);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Customers.Add(new Customer
            {
                CustomerName = model.CustomerName,
                Mail = model.Mail
            });
            context.SaveChanges();
        }

        public void UpdateElement(CustomerBindingModel model)
        {
            Customer element = context.Customers.FirstOrDefault(rec =>
                                    rec.CustomerName == model.CustomerName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Customers.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.CustomerName = model.CustomerName;
            element.Mail = model.Mail;
            context.SaveChanges();
        }

        public void DeleteElement(int id)
        {
            Customer element = context.Customers.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Customers.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
