using Microsoft.AspNetCore.Mvc;
using Monopoly.Model.Entities;
using Monopoly.Service.Services;
using System.Collections.Generic;

namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsController : ControllerBase
    {
        private FieldService service;
        public FieldsController(FieldService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public List<Field> Index(int page, int perPage)
        {
            Response.Headers.Add("X-Total-Count", service.Total().ToString());
            return service.GetAll(page, perPage);
        }
        [HttpGet("{id}")]
        public Field Details(int id)
        {
            return service.Get(id);
        }
        [HttpPost]
        public Field Create([FromBody] Field field)
        {
            return service.Create(null);
        }
        [HttpPut]
        public Field Edit([FromBody] Field field)
        {
            return service.Update(field);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            service.Delete(id);
        }

    }
}
