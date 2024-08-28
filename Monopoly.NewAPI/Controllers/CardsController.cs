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
    public class CardsController : ControllerBase
    {
        private ICardService service;
        public CardsController(ICardService service)
        {
            this.service = service;
        }
        [HttpGet("/api/games/{gameId}/[controller]")]
        public ActionResult<List<CardVM>> Index(int gameId, int page, int perPage)
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
        public ActionResult<CardVM> Details(int id)
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
        public ActionResult<CardVM> Create([FromBody] CardVM card)
        {
            try
            {
                return Ok(service.Create(card));
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
        public ActionResult<CardVM> Edit([FromBody] CardVM card)
        {
            try
            {
                return Ok(service.Update(card));
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
