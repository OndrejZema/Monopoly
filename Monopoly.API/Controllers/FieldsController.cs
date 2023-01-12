using Microsoft.AspNetCore.Mvc;
using Monopoly.Service.Services;
using System.Collections.Generic;
using Monopoly.Service.ViewModels;
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
        public List<FieldVM> Index(int page, int perPage)
        {
            Response.Headers.Add("X-Total-Count", service.TotalCount().ToString());
            return service.GetAll(page, perPage);
        }
        [HttpGet("{id}")]
        public FieldVM Details(int id)
        {
            return service.Get(id);
        }
        [HttpPost]
        public FieldVM Create([FromBody] FieldVM field)
        {
            return service.Create(field);
        }
        [HttpPut]
        public FieldVM Edit([FromBody] FieldVM field)
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
