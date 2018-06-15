using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualSoftwareWeb.Controllers
{
    public class CustomerSelectionController : Controller
    {
        private ICustomerService serviceC;

        private ISoftwareService serviceP;

        private IGeneralService serviceM;

        private static string sumPrice;

        public CustomerSelectionController(ICustomerService serviceC, ISoftwareService serviceP, IGeneralService serviceM)
        {
            this.serviceC = serviceC;
            this.serviceP = serviceP;
            this.serviceM = serviceM;
        }

        // GET: CustomerSelection
        public ActionResult CustomerSelection()
        {
            try
            {
                ViewBag.sumPrice = sumPrice;
                List<CustomerViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    ViewBag.listC = listC;
                }
                List<SoftwareViewModel> listP = serviceP.GetList();
                if (listP != null)
                {
                    ViewBag.listP = listP;
                }
            }
            catch (Exception ex)
            {
                RedirectPermanent("/CustomerSelection/WarningCustomerSelection");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CustomerSelection(OfferViewModel customerSelectionCount, string selectedItem1, string selectedItem2, string action, string sum)
        {
            if (string.IsNullOrEmpty(customerSelectionCount.ToString()))
            {
                return RedirectPermanent("/CustomerSelection/WarningCustomerSelection");
            }
            if (selectedItem1 == null)
            {
                return RedirectPermanent("/CustomerSelection/WarningCustomerSelection");
            }
            if (selectedItem2 == null)
            {
                return RedirectPermanent("/CustomerSelection/WarningCustomerSelection");
            }
            if (action.Equals("Подсчитать"))
            {
                CalcSum(customerSelectionCount, selectedItem1, selectedItem2);
                return RedirectPermanent("/CustomerSelection/CustomerSelection");
            }
            try
            {
                serviceM.CreateOffer(new OfferBindingModel
                {
                    CustomerId = Convert.ToInt32(selectedItem1),
                    SoftwareId = Convert.ToInt32(selectedItem2),
                    Number = Convert.ToInt32(customerSelectionCount.Number),
                    Summa = Convert.ToInt32(sum)
                });
                return RedirectPermanent("/General/General");
            }
            catch (Exception ex)
            {
                return RedirectPermanent("/CustomerSelection/WarningCustomerSelection");
            }
        }

        private string CalcSum(OfferViewModel customerSelectionCount, string selectedItem1, string selectedItem2)
        {
            if (customerSelectionCount != null)
            {
                try
                {
                    int id = Convert.ToInt32(selectedItem2);
                    SoftwareViewModel software = serviceP.GetElement(id);
                    int count = Convert.ToInt32(customerSelectionCount.Number);
                    sumPrice = (count * software.Cost).ToString();
                    ViewBag.sumPrice = sumPrice;
                    ViewBag.Count = Convert.ToInt32(customerSelectionCount.Number);
                    ViewBag.item1 = Convert.ToInt32(selectedItem1);
                    ViewBag.item2 = Convert.ToInt32(selectedItem2);
                    return sumPrice;
                }
                catch (Exception ex)
                {
                    RedirectPermanent("/CustomerSelection/WarningCustomerSelection");
                    return "Ошибка";
                }
            }
            RedirectPermanent("/CustomerSelection/WarningCustomerSelection");
            return "Ошибка";
        }

        public ActionResult WarningCustomerSelection()
        {
            return View();
        }
    }
}