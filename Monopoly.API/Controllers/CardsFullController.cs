using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Model;
using Monopoly.Service.Services;
using System.Collections.Generic;

namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsFullController : ControllerBase
    {
        private CardFullService service;
        public CardsFullController(CardFullService service) { 
            this.service = service;
        }

        [HttpGet]
        public List<CardFull> Index() {
            return service.GetAll();
        }
    }
}
