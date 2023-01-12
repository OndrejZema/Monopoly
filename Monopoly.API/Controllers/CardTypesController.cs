﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Repositories;
using Monopoly.Service.Services;
using Monopoly.Model.Entities;
using System.Collections.Generic;

namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardTypesController : ControllerBase
    {
        private CardTypeService service;
        public CardTypesController(CardTypeService service) {
            this.service = service; 
        }

        [HttpGet("")]
        public List<CardType> Index(int page, int perPage)
        {
            Response.Headers.Add("X-Total-Count", service.Total().ToString());
            return service.GetAll(page, perPage);
        }
        [HttpGet("{id}")]
        public CardType Details(int id)
        {
            return service.Get(id);
        }
        [HttpPost]
        public CardType Create([FromBody] CardType card)
        {
            return service.Create(null);
        }
        [HttpPut]
        public CardType Edit([FromBody] CardType card)
        {
            return service.Update(card);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
