using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoftwareDevelopmentService.ViewModels;

namespace VirtualSoftwareWeb.Controllers
{
    public class DeveloperController : Controller
    {
        public int Id { set { id = value; } }

        private IDeveloperService service;

        private int? id;

        public DeveloperController(IDeveloperService service)
        {
            this.service = service;
        }
        // GET: Developer
        public ActionResult Developer()
        {
            if (id.HasValue)
            {
                try
                {
                    DeveloperViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        //Исправить. var не нужен, нужно поле класса
                        var textBoxFIO = view.DeveloperName;
                        return View(textBoxFIO);
                    }
                }
                catch (Exception ex)
                {
                    return RedirectPermanent("/Developer/WarningDeveloper");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Developer(DeveloperViewModel objDeveloper)
        {
            if (string.IsNullOrEmpty(objDeveloper.DeveloperName))
            {
                return RedirectPermanent("/Developer/WarningDeveloper");
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdateElement(new DeveloperBindingModel
                    {
                        Id = id.Value,
                        DeveloperName = objDeveloper.DeveloperName
                    });
                }
                else
                {
                    service.AddElement(new DeveloperBindingModel
                    {
                        DeveloperName = objDeveloper.DeveloperName
                    });
                }
                return RedirectPermanent("/Developers/Developers");
            }
            catch (Exception ex)
            {
                return RedirectPermanent("/Developer/WarningDeveloper");
            }
        }
    }
}