using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualSoftware;
using VirtualSoftwarePlace.LogicInterface;
using VirtualSoftwarePlace.ConnectingModel;
using VirtualSoftwarePlace.UserViewModel;

namespace VirtualSoftwareWeb.Controllers
{
    public class DevelopersController : Controller
    {
        private IDeveloperService service;

        public DevelopersController(IDeveloperService service)
        {
            this.service = service;
        }
        // GET: Developers
        public ActionResult Developers()
        {
            LoadData();
            return View();
        }

        private void LoadData()
        {
            try
            {
                List<DeveloperUserViewModel> list = service.GetList();
                if (list != null)
                {
                    ViewBag.DataList = list;
                }
                else
                {
                    ViewBag.DataList = null;
                }
            }
            catch (Exception ex)
            {
                Redirect("/Developers/WarningDevelopers");
            }
        }

        public ActionResult WarningDevelopers()
        {
            return View();
        }


        [HttpPost]
        public RedirectResult Developers(string action, string developerList)
        {
            switch (action)
            {
                case "Add":
                    return DeveloperResult();
                case "Change":
                    break;
                case "Delete":
                    int id = Convert.ToInt32(developerList);
                    try
                    {
                        service.DelPart(id);
                    }
                    catch (Exception ex)
                    {
                        return RedirectPermanent("/Developers/WarningDevelopers");
                    }
                    LoadData();
                    return RedirectPermanent("/Developers/Developers");
                    break;
                case "Update":
                    return DevelopersResult();
            }
            return WarningResult();

        }

        public ActionResult WarningCustomer()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public RedirectResult DeveloperResult()
        {
            return RedirectPermanent("/Developer/Developer");
        }

        public RedirectResult WarningResult()
        {
            return RedirectPermanent("/Developers/WarningDevelopers");
        }

        public RedirectResult DevelopersResult()
        {
            return RedirectPermanent("/Developer/Developer");
        }

    }
}
