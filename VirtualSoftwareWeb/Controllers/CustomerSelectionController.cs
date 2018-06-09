using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualSoftwarePlace.LogicInterface;
using VirtualSoftwarePlace.UserViewModel;
using VirtualSoftwarePlace.ConnectingModel;
using VirtualSoftware;

namespace VirtualSoftwareWeb.Controllers
{
    public class CustomerSelectionController : Controller
    {
        private ICustomerCustomer serviceC;

        private ISoftwareService serviceP;

        private IGeneralSelection serviceM;

        private static string sumPrice;

        public CustomerSelectionController(ICustomerCustomer serviceC, ISoftwareService serviceP, IGeneralSelection serviceM)
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
                List<CustomerUserViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    ViewBag.listC = listC;
                }
                List<SoftwareUserViewModel> listP = serviceP.GetList();
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
        public ActionResult CustomerSelection(CustomerSelectionUserViewModel customerSelectionCount, string selectedItem1, string selectedItem2, string action, string sum)
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
                serviceM.CreateOrder(new CustomerSelectionModel
                {
                    CustomerId = Convert.ToInt32(selectedItem1),
                    SoftwareId = Convert.ToInt32(selectedItem2),
                    Count = Convert.ToInt32(customerSelectionCount.Count),
                    Sum = Convert.ToInt32(sum)
                });
                return RedirectPermanent("/General/General");
            }
            catch (Exception ex)
            {
                return RedirectPermanent("/CustomerSelection/WarningCustomerSelection");
            }
        }

        private string CalcSum(CustomerSelectionUserViewModel customerSelectionCount, string selectedItem1, string selectedItem2)
        {
            if (customerSelectionCount != null)
            {
                try
                {
                    int id = Convert.ToInt32(selectedItem2);
                    SoftwareUserViewModel software = serviceP.GetPart(id);
                    int count = Convert.ToInt32(customerSelectionCount.Count);
                    sumPrice = (count * software.Price).ToString();
                    ViewBag.sumPrice = sumPrice;
                    ViewBag.Count = Convert.ToInt32(customerSelectionCount.Count);
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
