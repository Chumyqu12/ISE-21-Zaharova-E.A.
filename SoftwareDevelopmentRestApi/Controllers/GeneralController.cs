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
    public class GeneralController : ApiController
    {
        private readonly IGeneralService _service;

        public GeneralController(IGeneralService service)
        {
            _service = service;
        }

        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }

        [HttpPost]
        public void CreateOffer(OfferBindingModel model)
        {
            _service.CreateOffer(model);
        }

        [HttpPost]
        public void TakeOfferInWork(OfferBindingModel model)
        {
            _service.TakeOfferInWork(model);
        }

        [HttpGet]
        public IHttpActionResult FinalOffer(/*OfferBindingModel model*/)
        {
            _service.FinalOffer(1);
            return Ok();
        }

        [HttpPost]
        public void CostOffer(OfferBindingModel model)
        {
            _service.CostOffer(model.Id);
        }

        [HttpPost]
        public void PutPartOnWarehouse(WarehousePartBindingModel model)
        {
            _service.PutPartOnWarehouse(model);
        }
    }
}
