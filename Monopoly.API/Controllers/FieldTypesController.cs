using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Repositories;
using Monopoly.Service.Services;
using Monopoly.Model.Entities;
using System.Collections.Generic;

namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldTypesController : ControllerBase
    {
        private FieldTypeService service;
        public FieldTypesController(FieldTypeService service) { 
            this.service = service;
        }   

        [HttpGet("")]
        public List<FieldType> Index()
        {
            Response.Headers.Add("X-Total-Count", service.Total().ToString());
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Total-Count");
            return service.GetAll();
        }
        [HttpGet("{id}")]
        public FieldType Details(int id)
        {
            return service.Get(id);
        }
        [HttpPost]
        public FieldType Create([FromBody] FieldType fieldType)
        {
            return service.Create(null);
        }
        [HttpPut]
        public FieldType Edit([FromBody] FieldType fieldType)
        {
            return service.Update(fieldType);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
