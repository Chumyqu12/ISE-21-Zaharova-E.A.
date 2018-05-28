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
    public class SoftwareWarehouseController : Controller
    {
        public int Id { set { id = value; } }

        private ISoftwareWarehouseService service;

        private int? id;

        public SoftwareWarehouseController(ISoftwareWarehouseService service)
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
                    SoftwareWarehouseUserViewModel view = service.GetPart(id.Value);
                    if (view != null)
                    {
                        var textBoxSoftwareWarehouseName = view.SoftwareWarehouseName;
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
        public ActionResult SoftwareWarehouse(SoftwareWarehouseUserViewModel objSoftwareWarehouse)
        {
            if (string.IsNullOrEmpty(objSoftwareWarehouse.ToString()))
            {
                return RedirectPermanent("/SoftwareWarehouse/SoftwareWarehouseWarning");
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdPart(new SoftwareWarehouseConnectingModel
                    {
                        Id = id.Value,
                        StockName = objSoftwareWarehouse.SoftwareWarehouseName
                    });
                }
                else
                {
                    service.AddPart(new SoftwareWarehouseConnectingModel
                    {
                        StockName = objSoftwareWarehouse.SoftwareWarehouseName
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
