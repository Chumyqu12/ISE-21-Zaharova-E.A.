using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualSoftwarePlace.LogicInterface;
using VirtualSoftwarePlace.UserViewModel;
using VirtualSoftware;
using Unity;
using Unity.Attributes;
using System.Web.UI.WebControls;

namespace VirtualSoftwareWeb.Controllers
{
    public class CustomerController : Controller
    {
        public int Id { set { id = value; } }

        private ICustomerCustomer service;

        private int? id;

        public CustomerController(ICustomerCustomer service)
        {
            this.service = service;
        }

        // GET: Customer
        public ActionResult Customer()
        {
            LoadData();
            return View();
        }

        [HttpPost]
        public RedirectResult Customer(string action, string customerList)
        {
            switch (action)
            {
                case "Add":
                    return SingleCustomerResult();
                case "Change":
                    break;
                case "Delete":
                    int id = Convert.ToInt32(customerList);
                    try
                    {
                        service.DelPart(id);
                    }
                    catch (Exception ex)
                    {
                        return RedirectPermanent("/Customer/WarningCustomer");
                    }
                    LoadData();
                    return RedirectPermanent("/Customer/Customer");
                    break;
                case "Update":
                    return CustomerResult();
            }
            return WarningResult();
        }

        public ActionResult WarningCustomer()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public RedirectResult SingleCustomerResult()
        {
            return RedirectPermanent("/SingleCustomer/SingleCustomer");
        }

        public RedirectResult WarningResult()
        {
            return RedirectPermanent("/Customer/WarningCustomer");
        }

        public RedirectResult CustomerResult()
        {
            return RedirectPermanent("/Customer/Customer");
        }

        private void LoadData()
        {
            try
            {
                List<CustomerUserViewModel> list = service.GetList();
                ViewBag.DataList = list;
            }
            catch (Exception ex)
            {
                View(WarningCustomer());
            }
        }
    }
}
