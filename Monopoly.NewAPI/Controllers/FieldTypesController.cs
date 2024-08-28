using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Exceptions;
using Monopoly.Service.Services;
using Monopoly.Service.ViewModels;
using System;
using System.Collections.Generic;
using Monopoly.Service.Services.Interfaces;

namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldTypesController : ControllerBase
    {
        private IFieldTypeService service;
        public FieldTypesController(IFieldTypeService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public ActionResult<List<FieldTypeVM>> Index(int? page, int? perPage)
        {
            try
            {
                Response.Headers.Add("X-Total-Count", service.TotalCount().ToString());
                return Ok(service.GetAll( page, perPage));
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
                return Ok(service.Get(id));
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
                return Ok(service.Create(fieldType));
            }
            catch (ValueException ex)
            {
                return StatusCode(400);
            }
        }
        [HttpPut]
        public ActionResult<FieldTypeVM> Edit([FromBody] FieldTypeVM fieldType)
        {
            try
            {
                return Ok(service.Update(fieldType));
            }
            catch (ValueException ex)
            {
                return StatusCode(400);
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
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
            catch(RecordWithDependenciesException ex)
            {
                return StatusCode(409);
            }
        }
    }
}
