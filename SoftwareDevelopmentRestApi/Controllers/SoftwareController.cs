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
    public class SoftwareController : ApiController
    {
        private readonly ISoftwareService _service;

        public SoftwareController(ISoftwareService service)
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
        public void AddElement(SoftwareBindingModel model)
        {
            _service.AddElement(model);
        }

        [HttpPost]
        public void UpdateElement(SoftwareBindingModel model)
        {
            _service.UpdateElement(model);
        }

        [HttpPost]
        public void DeleteElement(SoftwareBindingModel model)
        {
            _service.DeleteElement(model.Id);
        }

    }
}
