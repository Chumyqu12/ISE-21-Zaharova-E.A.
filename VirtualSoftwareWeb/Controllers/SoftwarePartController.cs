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
    public class SoftwarePartController : Controller
    {
        public SoftwarePartUserViewModel Model { set { model = value; } get { return model; } }

        private IPartService service;

        private SoftwarePartUserViewModel model;

        public SoftwarePartController(IPartService service)
        {
            this.service = service;
        }

        public ActionResult SoftwarePart()
        {
            try
            {
                List<PartUserViewModel> list = service.GetList();
                if (list != null)
                {
                    ViewBag.DataList = list;
                }
            }
            catch (Exception ex)
            {
                return RedirectPermanent("/SoftwarePart/SoftwarePartWarning");
            }
            if (model != null)
            {
                ViewBag.DataCountBox = model.Count.ToString();
            }
            return View();
        }

        public ActionResult SoftwarePartWarning()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SoftwarePart(SoftwarePartUserViewModel SoftwarePartCount, string selectedItem)
        {
            List<PartUserViewModel> list = service.GetList();
            PartUserViewModel x = list.ElementAt(Convert.ToInt32(selectedItem));
            if (SoftwarePartCount == null)
            {
                return RedirectPermanent("/SoftwarePart/SoftwarePartWarning");
            }
            if (selectedItem == null)
            {
                return RedirectPermanent("/SoftwarePart/SoftwarePartWarning");
            }
            try
            {
                if (model == null)
                {
                    model = new SoftwarePartUserViewModel
                    {
                        PartId = Convert.ToInt32(x.Id),
                        PartName = x.PartName,
                        Count = Convert.ToInt32(SoftwarePartCount.Count)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(SoftwarePartCount.Count);
                }
                return RedirectToAction("Software", "Software", model);

            }
            catch (Exception ex)
            {
                return RedirectPermanent("/SoftwarePart/SoftwarePartWarning");
            }
        }
    }
}
