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
    public class SoftwareController : Controller
    {
        public int Id { set { id = value; } }

        private ISoftwareService service;

        private int? id;

        private List<SoftwarePartUserViewModel> SoftwareParts = new List<SoftwarePartUserViewModel>();


        public SoftwareController(ISoftwareService service)
        {
            this.service = service;
        }
        // GET: Software
        public ActionResult Software(SoftwarePartUserViewModel model)
        {
            if (id.HasValue)
            {
                try
                {
                    SoftwareUserViewModel view = service.GetPart(id.Value);
                    if (view != null)
                    {
                        SoftwareParts = view.SoftwarePart;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    return RedirectPermanent("/Software/SoftwareWarning");
                }
            }
            else
            {
                
                if (model != null)
                {
                    SoftwareParts.Add(model);
                }
                LoadData();
            }
            return View();
        }

        [HttpPost]
        public RedirectResult Software(string action, string SoftwareList, string SoftwareName, string value)
        {
            switch (action)
            {
                case "Add":
                    return RedirectPermanent("/SoftwarePart/SoftwarePart");
                case "Change":
                    break;
                case "Delete":
                    int id = Convert.ToInt32(SoftwareList);
                    try
                    {
                        service.DelPart(id);
                    }
                    catch (Exception ex)
                    {
                        return RedirectPermanent("/Software/SoftwareWarning");
                    }
                    LoadData();
                    return RedirectPermanent("/Software/Software");
                    break;
                case "Update":
                    LoadData();
                    return RedirectPermanent("/Software/Software");
                case "Save":
                    SaveButton(SoftwareName, value);
                    return RedirectPermanent("/Softwares/Softwares");
                case "Cancel":
                    return RedirectPermanent("");
            }
            return RedirectPermanent("/Software/SoftwareWarning");
        }

        private void SaveButton(string SoftwareName, string value)
        {
            if (string.IsNullOrEmpty(SoftwareName))
            {
                RedirectPermanent("/Software/SoftwareWarning");
            }
            if (value == null)
            {
                RedirectPermanent("/Software/SoftwareWarning");
            }
            if (SoftwareParts == null || SoftwareParts.Count == 0)
            {
                RedirectPermanent("/Software/SoftwareWarning");
            }
            try
            {
                List<SoftwarePartConnectingModel> SoftwarePartBM = new List<SoftwarePartConnectingModel>();
                for (int i = 0; i < SoftwareParts.Count; ++i)
                {
                    SoftwarePartBM.Add(new SoftwarePartConnectingModel
                    {
                        Id = SoftwareParts[i].Id,
                        SoftwareId = SoftwareParts[i].SoftwareId,
                        PartId = SoftwareParts[i].PartId,
                        Count = SoftwareParts[i].Count
                    });
                }
                if (id.HasValue)
                {
                    service.UpdPart(new SoftwareConnectingModel
                    {
                        Id = id.Value,
                        SoftwareName = SoftwareName,
                        Value = Convert.ToInt32(value),
                        SoftwarePart = SoftwarePartBM
                    });
                }
                else
                {
                    service.AddPart(new SoftwareConnectingModel
                    {
                        SoftwareName = SoftwareName,
                        Value = Convert.ToInt32(value),
                        SoftwarePart = SoftwarePartBM
                    });
                }
                RedirectPermanent("/Softwares/Softwares");
            }
            catch (Exception ex)
            {
                RedirectPermanent("/Software/SoftwareWarning");

            }
        }

        private void LoadModel(SoftwarePartUserViewModel routeModel)
        {
            try
            {
                if (routeModel != null)
                {
                    SoftwareParts.Add(routeModel);
                    ViewBag.DataList = SoftwareParts;
                }
            }
            catch (Exception ex)
            {
                RedirectPermanent("/Software/SoftwareWarning");
            }
        }

        private void LoadData()
        {
            try
            {
                if (SoftwareParts != null)
                {
                    ViewBag.DataList = SoftwareParts;
                }
            }
            catch (Exception ex)
            {
                RedirectPermanent("/Software/SoftwareWarning");
            }
        }

    }
}
