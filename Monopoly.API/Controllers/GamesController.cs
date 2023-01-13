using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Exceptions;
using Monopoly.Service.Services;
using Monopoly.Service.ViewModels;
using System;
using System.Collections.Generic;
namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private GameService service;
        public GamesController(GameService service)
        {
            this.service = service;
        }

        //[HttpGet("{page}&{perPage}")]
        [HttpGet]
        public List<GameVM> Index(int page, int perPage)
        {
            try
            {
                Response.Headers.Add("X-Total-Count", service.TotalCount().ToString());
                return service.GetAll(page, perPage);
            }
            catch (NotFoundRecordException ex)
            {
                Response.StatusCode = 404;
                return null;
            }
        }
        [HttpGet("{id}")]
        public GameVM Details(int id)
        {
            try
            {
                return service.Get(id);
            }
            catch (NotFoundRecordException ex)
            {
                Response.StatusCode = 404;
                return null;
            }
        }
        [HttpPost]
        public GameVM Create([FromBody] GameVM game)
        {
            try
            {
                return service.Create(game);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return null;
            }
        }
        [HttpPut]
        public GameVM Edit([FromBody] GameVM game)
        {
            try
            {
                return service.Update(game);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return null;
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                service.Delete(id);
            }
            catch (NotFoundRecordException ex)
            {
                Response.StatusCode = 404;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
            }
        }

    }
}
