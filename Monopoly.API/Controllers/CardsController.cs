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
        public string Edit(int id, [FromBody]Card card)
        {
            return "";
        }
        [HttpDelete]
        public string Delete(int id)
        {
            return "delete";
        }
    }
}
