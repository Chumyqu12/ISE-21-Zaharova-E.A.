using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualSoftwareWeb.Controllers
{
    public class SoftwarePartController : Controller
    {
        public SoftwarePartViewModel Model { set { model = value; } get { return model; } }

        private IPartService service;

        private SoftwarePartViewModel model;

        public SoftwarePartController(IPartService service)
        {
            this.service = service;
        }

        public ActionResult SoftwarePart()
        {
            try
            {
                List<PartViewModel> list = service.GetList();
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
                ViewBag.DataCountBox = model.Number.ToString();
            }
            return View();
        }

        public ActionResult SoftwarePartWarning()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SoftwarePart(SoftwarePartViewModel SoftwarePartCount, string selectedItem)
        {
            List<PartViewModel> list = service.GetList();
            PartViewModel x = list.ElementAt(Convert.ToInt32(selectedItem));
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
                    model = new SoftwarePartViewModel
                    {
                        PartId = Convert.ToInt32(x.Id),
                        PartName = x.PartName,
                        Number = Convert.ToInt32(SoftwarePartCount.Number)
                    };
                }
                else
                {
                    model.Number = Convert.ToInt32(SoftwarePartCount.Number);
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