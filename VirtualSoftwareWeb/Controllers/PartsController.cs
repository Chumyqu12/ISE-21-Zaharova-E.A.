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
    public class PartsController : Controller
    {
        private IPartService service;

        public PartsController(IPartService service)
        {
            this.service = service;
        }
        // GET: Parts
        public ActionResult Parts()
        {
            LoadData();
            return View();
        }

        [HttpPost]
        public ActionResult Parts(string action, string partList)
        {
            switch (action)
            {
                case "Add":
                    return PartResult();
                case "Change":
                    break;
                case "Delete":
                    int id = Convert.ToInt32(partList);
                    try
                    {
                        service.DelPart(id);
                    }
                    catch (Exception ex)
                    {
                        return RedirectPermanent("/Parts/PartsWarning");
                    }
                    LoadData();
                    return RedirectPermanent("/Parts/Parts");
                    break;
                case "Update":
                    return CustomerResult();
            }
            return WarningResult();
        }

        public ActionResult PartsWarning()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult OkParts()
        {
            return View();
        }

        public RedirectResult PartResult()
        {
            return RedirectPermanent("/Part/Part");
        }

        public RedirectResult WarningResult()
        {
            return RedirectPermanent("/Parts/PartsWarning");
        }

        public RedirectResult CustomerResult()
        {
            return RedirectPermanent("/Parts/Parts");
        }

        private void LoadData()
        {
            try
            {
                List<PartUserViewModel> list = service.GetList();
                ViewBag.DataList = list;
            }
            catch (Exception ex)
            {
                View(PartsWarning());
            }
        }

    }
}
