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

        [HttpGet("")]
        public List<Game> Index()
        {
            return service.GetAll();
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
        public string Edit(int id, [FromBody] Game game)
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
