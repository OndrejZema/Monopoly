using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Exceptions;
using Monopoly.Service.Services;
using Monopoly.Service.ViewModels;
using System.Collections.Generic;
namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesPreviewController : ControllerBase
    {
        private GamePreviewService service;
        private GameService gameService;
        public GamesPreviewController(GamePreviewService service, GameService gameService)
        {
            this.service = service;
            this.gameService = gameService;
        }
        [HttpGet]
        public ActionResult<List<GamePreviewVM>> Index(int page, int perPage)
        {
            try
            {
                Response.Headers.Add("X-Total-Count", gameService.TotalCount().ToString());
                return Ok(service.GetAll(page, perPage));
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
    }
}
