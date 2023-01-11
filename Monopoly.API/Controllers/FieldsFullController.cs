using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Model;
using Monopoly.Service.Services;
using System.Collections.Generic;

namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsFullController : ControllerBase
    {
        private FieldFullService service;
        public FieldsFullController(FieldFullService service) {
            this.service = service;
        }
        [HttpGet]
        public List<FieldFull> Index()
        {
            return service.GetAll();
        }
    }
}
