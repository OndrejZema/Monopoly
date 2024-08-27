using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Repositories;
using Monopoly.Service.Services;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Service.ViewModels;
using Monopoly.Repository.Exceptions;
using System;

namespace Monopoly.NewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanknotesController : ControllerBase
    {
        private BanknoteService service;
        public BanknotesController(BanknoteService service) { 
            this.service = service; 
        }
        [HttpGet("/api/games/{gameId}/[controller]")]
        public ActionResult<List<BanknoteVM>> Index(int gameId, int page, int perPage)
        {
            Response.Headers.Add("X-Total-Count", service.TotalCount(gameId).ToString());
            try
            {
                return Ok(service.GetAll(gameId, page, perPage));
            }
            catch(NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public ActionResult<BanknoteVM> Details(int id)
        {
            try
            {
                return Ok(service.Get(id));
            }
            catch(NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult<BanknoteVM> Create([FromBody]BanknoteVM banknote)
        {
            try
            {
                return Ok(service.Create(banknote));
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
        public ActionResult<BanknoteVM> Edit([FromBody] BanknoteVM banknote)
        {
            try
            {
                return Ok(service.Update(banknote));
            }
            catch(NotFoundRecordException ex) {
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
            catch(NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
    }
}
