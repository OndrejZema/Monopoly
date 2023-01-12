using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Service.ViewModels;
using Monopoly.Service.Services;
using System.Collections.Generic;

namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesPreviewController : ControllerBase
    {
        private GamePreviewService service;
        private GameService gameService;
        public GamesPreviewController(GamePreviewService service, GameService gameService) {
            this.service = service;
            this.gameService = gameService;
        }
        [HttpGet]
        public List<GamePreviewVM> Index(int page, int perPage)
        {
            Response.Headers.Add("X-Total-Count", gameService.TotalCount().ToString());
            return service.GetAll(page, perPage);
        }
    }
}
