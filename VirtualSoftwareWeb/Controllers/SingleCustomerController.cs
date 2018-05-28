using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VirtualSoftware;
using VirtualSoftwarePlace.LogicInterface;
using VirtualSoftwarePlace.ConnectingModel;
using VirtualSoftwarePlace.UserViewModel;


namespace VirtualSoftwareWeb.Controllers
{
    public class SingleCustomerController : Controller
    {
        public int Id { set { id = value; } }

        private ICustomerCustomer service;

        private int? id;

        private string strCustomerFIO = "";

        public SingleCustomerController(ICustomerCustomer service)
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
                    CustomerUserViewModel view = service.GetPart(id.Value);
                    if (view != null)
                    {
                        strCustomerFIO = view.CustomerFIO;
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
        public ActionResult SingleCustomer(CustomerUserViewModel objCustomer)
        {
            if (string.IsNullOrEmpty(objCustomer.ToString()))
            {
                return RedirectPermanent("/SingleCustomer/SingleCustomerWarining");
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdPart(new CustomerConnectingModel
                    {
                        Id = id.Value,
                        CustomerFIO = objCustomer.CustomerFIO
                    });
                }
                else
                {
                    service.AddPart(new CustomerConnectingModel
                    {
                        CustomerFIO = objCustomer.CustomerFIO
                    });
                }
                return RedirectPermanent("/Customer/Customer");
            }
            catch (Exception ex)
            {
                return RedirectPermanent("/SingleCustomer/SingleCustomerWarining");
            }
            //return $"Покупатель {CustomerFIO} зарегистрирован";
        }
    }
}
