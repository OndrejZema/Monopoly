using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Model;
using Monopoly.Service.Services;
using System.Collections.Generic;

namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesPreviewController : ControllerBase
    {
        private GamePreviewService service;
        public GamesPreviewController(GamePreviewService service) {
            this.service = service;
        }
        [HttpGet]
        public List<GamePreview> Index()
        {
            return service.GetAll();
        }
    }
}
