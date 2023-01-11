using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Model;
using Monopoly.Service.Services;
using System.Collections.Generic;

namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanknotesFullController : ControllerBase
    {
        private BanknoteFullService service;
        public BanknotesFullController(BanknoteFullService service) { 
            this.service = service;
        }

        [HttpGet]
        public List<BanknoteFull> Index() {
            return service.GetAll();
        }

    }
}
