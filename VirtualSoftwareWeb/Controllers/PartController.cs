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
    public class PartController : Controller
    {
        public int Id { set { id = value; } }

        private IPartService service;

        private int? id;

        public PartController(IPartService service)
        {
            this.service = service;
        }

        // GET: Part
        public ActionResult Part()
        {
            if (id.HasValue)
            {
                try
                {
                    PartViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        var textBoxFIO = view.PartName;
                        return View(textBoxFIO);
                    }
                }
                catch (Exception ex)
                {
                    return RedirectPermanent("/Part/PartWarning");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Part(PartViewModel objPart)
        {
            if (string.IsNullOrEmpty(objPart.ToString()))
            {
                return RedirectPermanent("/Part/PartWarning");
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdateElement(new PartBindingModel
                    {
                        Id = id.Value,
                        PartName = objPart.PartName
                    });
                }
                else
                {
                    service.AddElement(new PartBindingModel
                    {
                        PartName = objPart.PartName
                    });
                }
                return RedirectPermanent("/Parts/Parts");
            }
            catch (Exception ex)
            {
                return RedirectPermanent("/Part/PartWarning");
            }
        }
    }
}