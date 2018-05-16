using SoftwareDevelopmentService.BindingModels;
using SoftwareDevelopmentService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SoftwareDevelopmentRestApi.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetWarehousesLoad()
        {
            var list = _service.GetWarehousesLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult GetCustomerOffers(ReportBindingModel model)
        {
            var list = _service.GetCustomerOffers(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public void SaveSoftwareCost(ReportBindingModel model)
        {
            _service.SaveSoftwareCost(model);
        }

        [HttpPost]
        public void SaveWarehousesLoad(ReportBindingModel model)
        {
            _service.SaveWarehousesLoad(model);
        }

        [HttpPost]
        public void SaveCustomerOffers(ReportBindingModel model)
        {
            _service.SaveCustomerOffers(model);
        }
    }
}
