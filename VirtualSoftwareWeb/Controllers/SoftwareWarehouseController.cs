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
    public class SoftwareWarehouseController : Controller
    {
        public int Id { set { id = value; } }

        private IWarehouseService service;

        private int? id;

        public SoftwareWarehouseController(IWarehouseService service)
        {
            this.service = service;
        }
        // GET: SoftwareWarehouse
        public ActionResult SoftwareWarehouse()
        {
            if (id.HasValue)
            {
                try
                {
                    WarehouseViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        var textBoxSoftwareWarehouseName = view.WarehouseName;
                        return View(textBoxSoftwareWarehouseName);
                    }
                }
                catch (Exception ex)
                {
                    return RedirectPermanent("/SoftwareWarehouse/SoftwareWarehouseWarning");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult SoftwareWarehouse(WarehouseViewModel objSoftwareWarehouse)
        {
            if (string.IsNullOrEmpty(objSoftwareWarehouse.ToString()))
            {
                return RedirectPermanent("/SoftwareWarehouse/SoftwareWarehouseWarning");
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdateElement(new WarehouseBindingModel
                    {
                        Id = id.Value,
                        WarehouseName = objSoftwareWarehouse.WarehouseName
                    });
                }
                else
                {
                    service.AddElement (new WarehouseBindingModel
                    {
                        WarehouseName = objSoftwareWarehouse.WarehouseName
                    });
                }
                return RedirectPermanent("/SoftwareWarehouses/SoftwareWarehouses");
            }
            catch (Exception ex)
            {
                return RedirectPermanent("/SoftwareWarehouse/SoftwareWarehouseWarning");
            }
        }
    }
}