using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualSoftwareWeb.Controllers
{
    public class SoftwareWarehousesController : Controller
    {
        // GET: SoftwareWarehouses
        private IWarehouseService service;

        public SoftwareWarehousesController(IWarehouseService service)
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
                        service.DeleteElement (id);
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
                List<WarehouseViewModel> list = service.GetList();
                ViewBag.DataList = list;
            }
            catch (Exception ex)
            {
                RedirectPermanent("/SoftwareWarehouses/SoftwareWarehousesWarning");
            }
        }
    }
}