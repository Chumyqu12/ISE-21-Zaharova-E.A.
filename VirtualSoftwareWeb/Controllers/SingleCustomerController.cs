using SoftwareDevelopmentModel;
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
    public class SingleCustomerController : Controller
    {
        public int Id { set { id = value; } }

        private ICustomerService service;

        private int? id;

        private string strCustomerFIO = "";

        public SingleCustomerController(ICustomerService service)
        {
            this.service = service;
        }

        // GET: SingleCustomer
        public ActionResult SingleCustomer()
        {
            if (id.HasValue)
            {
                try
                {
                    CustomerViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        strCustomerFIO = view.CustomerName;
                        return View(strCustomerFIO);
                    }
                }
                catch (Exception ex)
                {
                    Redirect("/SingleCustomer/SingleCustomerWarning");
                }
            }
            return View(new Customer());
        }

        public ActionResult SingleCustomerOK()
        {
            ViewBag.Message = "Покупатель успешно создан.";

            return View();
        }

        public ActionResult SingleCustomerWarining()
        {
            ViewBag.Message = "Ошибка.";

            return View();
        }


        [HttpPost]
        public ActionResult SingleCustomer(CustomerViewModel objCustomer)
        {
            if (string.IsNullOrEmpty(objCustomer.ToString()))
            {
                return RedirectPermanent("/SingleCustomer/SingleCustomerWarining");
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdateElement(new CustomerBindingModel
                    {
                        Id = id.Value,
                        CustomerName = objCustomer.CustomerName
                    });
                }
                else
                {
                    service.AddElement(new CustomerBindingModel
                    {
                        CustomerName = objCustomer.CustomerName
                    });
                }
                return RedirectPermanent("/Customer/Customer");
            }
            catch (Exception ex)
            {
                return RedirectPermanent("/SingleCustomer/SingleCustomerWarining");
            }
          
        }
    }
}