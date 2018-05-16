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
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
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

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

        [HttpPost]
        public void AddElement(CustomerBindingModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdateElement(CustomerBindingModel model)
        {
            _service.UpdateElement(model);
        }

        [HttpPost]
        public void DeleteElement(CustomerBindingModel model)
        {
            _service.DeleteElement(model.Id);
        }
    }
}
