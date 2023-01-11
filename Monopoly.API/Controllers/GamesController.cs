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
    public class GamesController : ControllerBase
    {
        private GameService service;
        public GamesController(GameService service) {
            this.service= service;
        }

        //[HttpGet("{page}&{perPage}")]
        [HttpGet]
        public List<Game> Index(int page, int perPage)
        {
            Response.Headers.Add("X-Total-Count", service.Total().ToString());
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Expose-Headers", "X-Total-Count");
            return service.GetAll(page, perPage);
        }
        [HttpGet("{id}")]
        public Game Details(int id)
        {
            return service.Get(id);
        }
        [HttpPost]
        public Game Create([FromBody] Game game)
        {
            return service.Create(null);
        }
        [HttpPut]
        public Game Edit(int id, [FromBody] Game game)
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
