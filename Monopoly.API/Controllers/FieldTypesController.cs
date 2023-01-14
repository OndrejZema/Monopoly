using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Exceptions;
using Monopoly.Service.Services;
using Monopoly.Service.ViewModels;
using System;
using System.Collections.Generic;
namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldTypesController : ControllerBase
    {
        private FieldTypeService service;
        public FieldTypesController(FieldTypeService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public ActionResult<List<FieldTypeVM>> Index(int? page, int? perPage)
        {
            try
            {
                Response.Headers.Add("X-Total-Count", service.TotalCount().ToString());
                return service.GetAll(page, perPage);
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public ActionResult<FieldTypeVM> Details(int id)
        {
            try
            {
                return service.Get(id);
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult<FieldTypeVM> Create([FromBody] FieldTypeVM fieldType)
        {
            try
            {
                return service.Create(fieldType);
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
        [HttpPut]
        public ActionResult<FieldTypeVM> Edit([FromBody] FieldTypeVM fieldType)
        {
            try
            {
                return service.Update(fieldType);
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                return Ok();
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
    }
}
