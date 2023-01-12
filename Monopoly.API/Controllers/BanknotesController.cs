using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Repositories;
using Monopoly.Service.Services;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Service.ViewModels;
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
        public List<BanknoteVM> Index(int page, int perPage)
        {
            Response.Headers.Add("X-Total-Count", service.TotalCount().ToString());
            return service.GetAll(page, perPage);
        }
        [HttpGet("{id}")]
        public BanknoteVM Details(int id)
        {
            return service.Get(id);
        }
        [HttpPost]
        public BanknoteVM Create([FromBody]BanknoteVM banknote)
        {
            return service.Create(banknote);
        }
        [HttpPut]
        public BanknoteVM Edit([FromBody] BanknoteVM banknote)
        {
            return service.Update(banknote);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
