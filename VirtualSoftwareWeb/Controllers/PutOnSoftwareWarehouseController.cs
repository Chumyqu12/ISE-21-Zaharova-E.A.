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
    public class PutOnSoftwareWarehouseController : Controller
    {
        private ISoftwareWarehouseService serviceS;

        private IPartService serviceC;

        private IGeneralSelection serviceM;

        public PutOnSoftwareWarehouseController(ISoftwareWarehouseService serviceS, IPartService serviceC, IGeneralSelection serviceM)
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
                List<PartUserViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    ViewBag.listC = listC;
                }
                List<SoftwareWarehouseUserViewModel> listS = serviceS.GetList();
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
                serviceM.PutComponentOnStock(new SoftwareWarehousePartConnectingModel
                {
                    PartId = Convert.ToInt32(selectedItem1),
                    SoftwareWarehouseId = Convert.ToInt32(selectedItem2),
                    Count = Convert.ToInt32(count)
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
