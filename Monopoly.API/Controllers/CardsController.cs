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
    public class CardsController : ControllerBase
    {
        private CardService service;
        public CardsController(CardService service)
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
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPut]
        public ActionResult<CardVM> Edit([FromBody] CardVM card)
        {
            try
            {
                return Ok(service.Update(card));
            }
            catch(Exception ex)
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
