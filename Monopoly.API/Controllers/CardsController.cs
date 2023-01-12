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
    public class CardsController : ControllerBase
    {
        private CardService service;
        public CardsController(CardService service) {
            this.service = service;
        }
        [HttpGet("")]
        public List<CardVM> Index(int page, int perPage)
        {
            Response.Headers.Add("X-Total-Count", service.TotalCount().ToString());
            return service.GetAll(page, perPage);
        }
        [HttpGet("{id}")]
        public CardVM Details(int id)
        {
            return service.Get(id);
        }
        [HttpPost]
        public CardVM Create([FromBody] CardVM card)
        {
            return service.Create(null);
        }
        [HttpPut]
        public CardVM Edit([FromBody]CardVM card)
        {
            return service.Update(card);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
