using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Exceptions;
using Monopoly.Service.Services;
using Monopoly.Service.ViewModels;
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
                Response.Headers.Add("X-Total-Count", service.TotalCount(gameId).ToString());
                return Ok(service.GetAll(gameId, page, perPage));
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
                return Ok(service.Get(id));
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
                return Ok(service.Create(field));
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
            catch (ValueException ex)
            {
                return StatusCode(400);
            }
        }
        [HttpPut]
        public ActionResult<FieldVM> Edit([FromBody] FieldVM field)
        {
            try
            {
                return Ok(service.Update(field));
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
            catch (ValueException ex)
            {
                return StatusCode(400);
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
            catch (RecordWithDependenciesException ex)
            {
                return StatusCode(409);
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
        }

    }
}
