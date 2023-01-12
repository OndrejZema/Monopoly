using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Repositories;
using Monopoly.Service.Services;
using System.Collections.Generic;
using Monopoly.Service.ViewModels;
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
        public List<FieldTypeVM> Index(int page, int perPage)
        {
            Response.Headers.Add("X-Total-Count", service.TotalCount().ToString());
            return service.GetAll(page, perPage);
        }
        [HttpGet("{id}")]
        public FieldTypeVM Details(int id)
        {
            return service.Get(id);
        }
        [HttpPost]
        public FieldTypeVM Create([FromBody] FieldTypeVM fieldType)
        {
            return service.Create(fieldType);
        }
        [HttpPut]
        public FieldTypeVM Edit([FromBody] FieldTypeVM fieldType)
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
