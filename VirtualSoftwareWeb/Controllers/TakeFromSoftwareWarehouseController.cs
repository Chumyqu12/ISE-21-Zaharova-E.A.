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
    public class TakeFromSoftwareWarehouseController : Controller
    {
        public int Id { set { id = value; } }

        private IDeveloperService serviceI;

        private IGeneralSelection serviceM;

        private int? id;


        public TakeFromSoftwareWarehouseController(IDeveloperService serviceI, IGeneralSelection serviceM)
        {
            this.serviceI = serviceI;
            this.serviceM = serviceM;
        }
        // GET: TakeFromSoftwareWarehouse
        public ActionResult TakeFromSoftwareWarehouse()
        {
            List<DeveloperUserViewModel> listI = serviceI.GetList();
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
                serviceM.TakeOrderInWork(new CustomerSelectionModel
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
