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
    public class FieldsController : ControllerBase
    {
        private FieldService service;
        public FieldsController(FieldService service)
        {
            this.service = service;
        }

        [HttpGet("/api/games/{gameId}/[controller]")]
        public ActionResult<List<FieldVM>> Index(int gameId, int page, int perPage)
        {
            try
            {
                Response.Headers.Add("X-Total-Count", service.TotalCount().ToString());
                return service.GetAll(gameId, page, perPage);
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public ActionResult<FieldVM> Details(int id)
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
        public ActionResult<FieldVM> Create([FromBody] FieldVM field)
        {
            try
            {
                return service.Create(field);
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
        [HttpPut]
        public ActionResult<FieldVM> Edit([FromBody] FieldVM field)
        {
            try
            {
                return service.Update(field);
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
