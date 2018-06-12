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
                    DeveloperUserViewModel view = service.GetPart(id.Value);
                    if (view != null)
                    {
                        //Исправить. var не нужен, нужно поле класса
                        var textBoxFIO = view.DeveloperFIO;
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
        public ActionResult Developer(DeveloperUserViewModel objDeveloper)
        {
            if (string.IsNullOrEmpty(objDeveloper.DeveloperFIO))
            {
                return RedirectPermanent("/Developer/WarningDeveloper");
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdPart(new DeveloperConnectingModel
                    {
                        Id = id.Value,
                        DeveloperFIO = objDeveloper.DeveloperFIO
                    });
                }
                else
                {
                    service.AddPart(new DeveloperConnectingModel
                    {
                        DeveloperFIO = objDeveloper.DeveloperFIO
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
