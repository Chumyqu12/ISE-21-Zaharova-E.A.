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
                    PartUserViewModel view = service.GetPart(id.Value);
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
        public ActionResult Part(PartUserViewModel objPart)
        {
            if (string.IsNullOrEmpty(objPart.ToString()))
            {
                return RedirectPermanent("/Part/PartWarning");
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdPart(new PartConnectingModel
                    {
                        Id = id.Value,
                        PartName = objPart.PartName
                    });
                }
                else
                {
                    service.AddPart(new PartConnectingModel
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
