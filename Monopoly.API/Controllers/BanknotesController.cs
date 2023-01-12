using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Repositories;
using Monopoly.Service.Services;
using Monopoly.Model.Entities;
using System.Collections.Generic;
using Monopoly.API.Models.ViewModels;
using System.Linq;

namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanknotesController : ControllerBase
    {
        private BanknoteService service;
        public BanknotesController(BanknoteService service) { 
            this.service = service; 
        }
        [HttpGet]
        public List<Banknote> Index(int page, int perPage)
        {
            Response.Headers.Add("X-Total-Count", service.Total().ToString());
            return service.GetAll(page, perPage);
        }
        [HttpGet("{id}")]
        public Banknote Details(int id)
        {
            return service.Get(id);
        }
        [HttpPost]
        public Banknote Create([FromBody]BanknoteVM banknote)
        {
            return service.Create(banknote);
        }
        [HttpPut]
        public Banknote Edit([FromBody] Banknote banknote)
        {
            return service.Update(banknote);
        }
        [HttpDelete]
        public string Delete(int id)
        {
            return "delete";
        }
    }
}
