using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Exceptions;
using Monopoly.Service.Services;
using Monopoly.Service.ViewModels;
using System.Collections.Generic;
using Monopoly.Service.Services.Interfaces;

namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesPreviewController : ControllerBase
    {
        private IGamePreviewService service;
        private IGameService gameService;
        public GamesPreviewController(IGamePreviewService service, IGameService gameService)
        {
            this.service = service;
            this.gameService = gameService;
        }
        [HttpGet]
        public ActionResult<List<GamePreviewVM>> Index(int page, int perPage)
        {
            string token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            try
            {
                Response.Headers.Add("X-Total-Count", gameService.TotalCount().ToString());
                return Ok(service.GetAll( page, perPage));
            }
            catch (NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
    }
}
