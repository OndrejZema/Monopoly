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
    public class GamesController : ControllerBase
    {
        private GameService service;
        public GamesController(GameService service) {
            this.service= service;
        }

        //[HttpGet("{page}&{perPage}")]
        [HttpGet]
        public List<GameVM> Index(int page, int perPage)
        {
            Response.Headers.Add("X-Total-Count", service.TotalCount().ToString());
            return service.GetAll(page, perPage);
        }
        [HttpGet("{id}")]
        public GameVM Details(int id)
        {
            return service.Get(id);
        }
        [HttpPost]
        public GameVM Create([FromBody] GameVM game)
        {
            return service.Create(game);
        }
        [HttpPut]
        public GameVM Edit([FromBody] GameVM game)
        {
            return service.Update(game);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            service.Delete(id);
        }

    }
}
