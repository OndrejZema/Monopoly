using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Model;
using Monopoly.Service.Services;
using System.Collections.Generic;

namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FullCardsController : ControllerBase
    {
        private FullCardService service;
        public FullCardsController(FullCardService service) { 
            this.service = service;
        }

        public List<FullCard> Index() {
            return service.GetAll();
        }

        public FullCard Detail(int index) {
            return service.Get(index);
        }
    }
}
