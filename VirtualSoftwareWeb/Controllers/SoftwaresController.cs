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
    public class SoftwaresController : Controller
    {
        private ISoftwareService service;

        public SoftwaresController(ISoftwareService service)
        {
            this.service = service;
        }
        public ActionResult Softwares()
        {
            LoadData();
            return View();
        }

        [HttpPost]
        public RedirectResult Softwares(string action, string SoftwaresList)
        {
            switch (action)
            {
                case "Add":
                    return RedirectPermanent("/Software/Software");
                case "Change":
                    break;
                case "Delete":
                    int id = Convert.ToInt32(SoftwaresList);
                    try
                    {
                        service.DelPart(id);
                    }
                    catch (Exception ex)
                    {
                        return RedirectPermanent("/Softwares/SoftwaresWarning");
                    }
                    LoadData();
                    return RedirectPermanent("/Customer/Customer");
                    break;
                case "Update":
                    return RedirectPermanent("/Softwares/Softwares");
            }
            return RedirectPermanent("/Softwares/SoftwaresWarning");

        }

        private void LoadData()
        {
            try
            {
                List<SoftwareUserViewModel> list = service.GetList();
                ViewBag.DataList = list;
            }
            catch (Exception ex)
            {
                RedirectPermanent("/Softwares/SoftwaresWarning");
            }
        }
    }
}
