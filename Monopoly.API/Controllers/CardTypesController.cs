using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Repositories;
using Monopoly.Service.Services;
using System.Collections.Generic;
using Monopoly.Service.ViewModels;
namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardTypesController : ControllerBase
    {
        private CardTypeService service;
        public CardTypesController(CardTypeService service) {
            this.service = service; 
        }

        [HttpGet("")]
        public List<CardTypeVM> Index(int page, int perPage)
        {
            Response.Headers.Add("X-Total-Count", service.TotalCount().ToString());
            return service.GetAll(page, perPage);
        }
        [HttpGet("{id}")]
        public CardTypeVM Details(int id)
        {
            return service.Get(id);
        }
        [HttpPost]
        public CardTypeVM Create([FromBody] CardTypeVM cardType)
        {
            return service.Create(cardType);
        }
        [HttpPut]
        public CardTypeVM Edit([FromBody] CardTypeVM cardType)
        {
            return service.Update(cardType);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
