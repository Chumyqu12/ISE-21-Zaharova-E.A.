using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualSoftwareWeb.Controllers
{
    public class GeneralController : Controller
    {
        private IGeneralService service;

        public GeneralController(IGeneralService service)
        {
            this.service = service;
        }

        // GET: General
        public ActionResult General()
        {
            LoadData();
            return View();
        }

        [HttpPost]
        public RedirectResult General(string action, string generalList)
        {
            switch (action)
            {
                case "Создать заказ":
                    return RedirectPermanent("/CustomerSelection/CustomerSelection");
                case "Отдать на выполнение":
                    return RedirectPermanent("/TakeFromSoftwareWarehouse/TakeFromSoftwareWarehouse");
                case "Заказ готов":
                    int id1 = Convert.ToInt32(generalList);
                    try
                    {
                        service.FinalOffer(id1);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        return RedirectPermanent("/General/GeneralWarning");
                    }
                    break;
                case "Заказ оплачен":
                    int id2 = Convert.ToInt32(generalList);
                    try
                    {
                        service.CostOffer(id2);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        return RedirectPermanent("/General/GeneralWarning");
                    }
                    break;
                case "Обновить список":
                    LoadData();
                    return RedirectPermanent("/General/General");
            }
            return RedirectPermanent("/General/GeneralWarning");
        }

        private void LoadData()
        {
            try
            {
                List<OfferViewModel> list = service.GetList();
                if (list != null)
                {
                    ViewBag.DataList = list;
                }
            }
            catch (Exception ex)
            {
                RedirectPermanent("/General/GeneralWarning");
            }
        }

        public ActionResult GeneralWarning()
        {
            return View();
        }
    }
}