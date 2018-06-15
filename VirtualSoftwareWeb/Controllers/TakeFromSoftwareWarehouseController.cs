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
    public class TakeFromSoftwareWarehouseController : Controller
    {
        public int Id { set { id = value; } }

        private IDeveloperService serviceI;

        private IGeneralService serviceM;

        private int? id;


        public TakeFromSoftwareWarehouseController(IDeveloperService serviceI, IGeneralService serviceM)
        {
            this.serviceI = serviceI;
            this.serviceM = serviceM;
        }
        // GET: TakeFromSoftwareWarehouse
        public ActionResult TakeFromSoftwareWarehouse()
        {
            List<DeveloperViewModel> listI = serviceI.GetList();
            ViewBag.DataList = listI;
            if (id.HasValue)
            {
                try
                {
                    //   List<DeveloperUserViewModel> listI = serviceI.GetList();
                    if (listI != null)
                    {
                        ViewBag.DataList = listI;
                    }
                }
                catch (Exception ex)
                {
                    return RedirectPermanent("/TakeFromSoftwareWarehouseWarning/TakeFromSoftwareWarehouseWarning");
                }
            }
            return View();
        }

        public ActionResult TakeFromSoftwareWarehouseWarning()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TakeFromSoftwareWarehouse(string selectedItem)
        {
            if (selectedItem == null)
            {
                return RedirectPermanent("/TakeFromSoftwareWarehouse/TakeFromSoftwareWarehouseWarning");
            }
            try
            {
                serviceM.TakeOfferInWork(new OfferBindingModel
                {
                    Id = id.Value,
                    DeveloperId = Convert.ToInt32(selectedItem)
                });
                return RedirectPermanent("/General/General");
            }
            catch (Exception ex)
            {
                return RedirectPermanent("/TakeFromSoftwareWarehouse/TakeFromSoftwareWarehouseWarning");
            }
        }
    }
}