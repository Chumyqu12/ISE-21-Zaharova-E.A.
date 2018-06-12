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
    public class SoftwareWarehousesController : Controller
    {
        private ISoftwareWarehouseService service;

        public SoftwareWarehousesController(ISoftwareWarehouseService service)
        {
            this.service = service;
        }
        // GET: SoftwareWarehouses
        public ActionResult SoftwareWarehouses()
        {
            LoadData();
            return View();
        }

        [HttpPost]
        public RedirectResult SoftwareWarehouses(string action, string softwareWarehouseList)
        {
            switch (action)
            {
                case "Add":
                    return RedirectPermanent("/SoftwareWarehouse/SoftwareWarehouse");
                case "Change":
                    break;
                case "Delete":
                    int id = Convert.ToInt32(softwareWarehouseList);
                    try
                    {
                        service.DelPart(id);
                    }
                    catch (Exception ex)
                    {
                        return RedirectPermanent("/SoftwareWarehouses/SoftwareWarehousesWarning");
                    }
                    LoadData();
                    return RedirectPermanent("/SoftwareWarehouses/SoftwareWarehouses");
                    break;
                case "Update":
                    return RedirectPermanent("/SoftwareWarehouses/SoftwareWarehouses");
            }
            return RedirectPermanent("/SoftwareWarehouses/SoftwareWarehousesWarning");
        }

        private void LoadData()
        {
            try
            {
                List<SoftwareWarehouseUserViewModel> list = service.GetList();
                ViewBag.DataList = list;
            }
            catch (Exception ex)
            {
                RedirectPermanent("/SoftwareWarehouses/SoftwareWarehousesWarning");
            }
        }
    }
}
