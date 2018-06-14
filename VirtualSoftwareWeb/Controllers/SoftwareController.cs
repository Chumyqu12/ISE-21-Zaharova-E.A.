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
    public class SoftwareController : Controller
    {
        public int Id { set { id = value; } }

        private ISoftwareService service;

        private int? id;

        private List<SoftwarePartViewModel> SoftwareParts = new List<SoftwarePartViewModel>();


        public SoftwareController(ISoftwareService service)
        {
            this.service = service;
        }
        // GET: Software
        public ActionResult Software(SoftwarePartViewModel model)
        {
            if (id.HasValue)
            {
                try
                {
                    SoftwareViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        SoftwareParts = view.SoftwareParts;
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
                        service.DeleteElement(id);
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
                List<SoftwarePartBindingModel> SoftwarePartBM = new List<SoftwarePartBindingModel>();
                for (int i = 0; i < SoftwareParts.Count; ++i)
                {
                    SoftwarePartBM.Add(new SoftwarePartBindingModel
                    {
                        Id = SoftwareParts[i].Id,
                        SoftwareId = SoftwareParts[i].SoftwareId,
                        PartId = SoftwareParts[i].PartId,
                        Number = SoftwareParts[i].Number
                    });
                }
                if (id.HasValue)
                {
                    service.UpdateElement(new SoftwareBindingModel
                    {
                        Id = id.Value,
                        SoftwareName = SoftwareName,
                        Cost= Convert.ToInt32(value),
                        SoftwareParts = SoftwarePartBM
                    });
                }
                else
                {
                    service.AddElement(new SoftwareBindingModel
                    {
                        SoftwareName = SoftwareName,
                        Cost = Convert.ToInt32(value),
                        SoftwareParts = SoftwarePartBM
                    });
                }
                RedirectPermanent("/Softwares/Softwares");
            }
            catch (Exception ex)
            {
                RedirectPermanent("/Software/SoftwareWarning");

            }
        }

        private void LoadModel(SoftwarePartViewModel routeModel)
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