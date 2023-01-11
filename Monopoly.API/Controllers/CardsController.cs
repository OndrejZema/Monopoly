using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Repositories;
using Monopoly.Service.Services;
using Monopoly.Model.Entities;
using System.Collections.Generic;

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
        public List<Card> Index()
        {
            Response.Headers.Add("X-Total-Count", service.Total().ToString());
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Total-Count");
            return service.GetAll();
        }
        [HttpGet("{id}")]
        public Card Details(int id)
        {
            return service.Get(id);
        }
        [HttpPost]
        public Card Create(IFormCollection collection)
        {
            return service.Create(null);
        }
        [HttpPut]
        public Card Edit(int id, [FromBody]Card card)
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
