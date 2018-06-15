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
    public class PutOnSoftwareWarehouseController : Controller
    {
        private IWarehouseService serviceS;

        private IPartService serviceC;

        private IGeneralService serviceM;

        public PutOnSoftwareWarehouseController(IWarehouseService serviceS, IPartService serviceC, IGeneralService serviceM)
        {
            this.serviceS = serviceS;
            this.serviceC = serviceC;
            this.serviceM = serviceM;
        }

        // GET: PutOnSoftwareWarehouse
        public ActionResult PutOnSoftwareWarehouse()
        {
            try
            {
                List<PartViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    ViewBag.listC = listC;
                }
                List<WarehouseViewModel> listS = serviceS.GetList();
                if (listS != null)
                {
                    ViewBag.listS = listS;
                }
            }
            catch (Exception ex)
            {
                return RedirectPermanent("/PutOnSoftwareWarehouse/WarningPutOnSoftwareWarehouse");
            }
            return View();
        }


        [HttpPost]
        public ActionResult PutOnSoftwareWarehouse(string count, string selectedItem1, string selectedItem2, string action)
        {
            if (action.Equals("Проверить"))
            {
                return RedirectPermanent("/PutOnSoftwareWarehouse/WarningPutOnSoftwareWarehouse");
            }
            if (count == null)
            {
                return RedirectPermanent("/PutOnSoftwareWarehouse/WarningPutOnSoftwareWarehouse");
            }
            if (selectedItem1 == null)
            {
                return RedirectPermanent("/PutOnSoftwareWarehouse/WarningPutOnSoftwareWarehouse");
            }
            if (selectedItem2 == null)
            {
                return RedirectPermanent("/PutOnSoftwareWarehouse/WarningPutOnSoftwareWarehouse");
            }
            try
            {
                serviceM.PutPartOnWarehouse(new WarehousePartBindingModel
                {
                    PartId = Convert.ToInt32(selectedItem1),
                    WarehouseId = Convert.ToInt32(selectedItem2),
                    Number = Convert.ToInt32(count)
                });
                return RedirectPermanent("/General/General");
            }
            catch (Exception ex)
            {
                return RedirectPermanent("/PutOnSoftwareWarehouse/WarningPutOnSoftwareWarehouse");
            }
        }
    }
}