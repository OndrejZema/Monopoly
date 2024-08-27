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
    public class GamesController : ControllerBase
    {
        private GameService service;
        public GamesController(GameService service)
        {
            this.service = service;
        }

        //[HttpGet("{page}&{perPage}")]
        [HttpGet]
        public ActionResult<List<GameVM>> Index(int page, int perPage)
        {
            try
            {
                Response.Headers.Add("X-Total-Count", service.TotalCount().ToString());
                return Ok(service.GetAll(page, perPage));
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public ActionResult<GameVM> Details(int id)
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
        public ActionResult<GameVM> Create([FromBody] GameVM game)
        {
            try
            {
                return Ok(service.Create(game));
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
        [HttpPut]
        public ActionResult<GameVM> Edit([FromBody] GameVM game)
        {
            try
            {
                return Ok(service.Update(game));
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
            catch(ValueException ex)
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
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
            catch (RecordWithDependenciesException ex)
            {
                return StatusCode(409);
            }
        }

    }
}
