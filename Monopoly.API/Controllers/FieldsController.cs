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
    public class FieldsController : ControllerBase
    {
        private FieldService service;
        public FieldsController(FieldService service) { 
            this.service= service;
        }

        [HttpGet("")]
        public List<Field> Index()
        {
            return service.GetAll();
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
        public string Edit(int id, [FromBody] Field field)
        {
            return "";
        }
        [HttpDelete]
        public string Delete(int id)
        {
            return "delete";
        }
    }
}
