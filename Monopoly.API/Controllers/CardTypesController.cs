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
    public class CardTypesController : ControllerBase
    {
        private CardTypeService service;
        public CardTypesController(CardTypeService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public ActionResult<List<CardTypeVM>> Index(int page, int perPage)
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
        public ActionResult<CardTypeVM> Details(int id)
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
        public ActionResult<CardTypeVM> Create([FromBody] CardTypeVM cardType)
        {
            try
            {
                return service.Create(cardType);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return null;
            }
        }
        [HttpPut]
        public ActionResult<CardTypeVM> Edit([FromBody] CardTypeVM cardType)
        {
            try
            {
                return service.Update(cardType);
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
