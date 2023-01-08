﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Repositories;
using Monopoly.Service.Services;
using Monopoly.Model.Entities;
using System.Collections.Generic;
using Monopoly.API.Models.ViewModels;
namespace Monopoly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanknotesController : ControllerBase
    {
        private BanknoteService service;
        public BanknotesController(BanknoteService service) { 
            this.service = service; 
        }
        [HttpGet("")]
        public List<Banknote> Index()
        {
            return service.GetAll();
        }
        [HttpGet("{id}")]
        public Banknote Details(int id)
        {
            return service.Get(id);
        }
        [HttpGet("/total")]
        public int Total() { 
            return service.Total();
        }
        [HttpPost]
        public Banknote Create(BanknoteVM banknote)
        {
            return service.Create(null);
        }
        [HttpPut]
        public Banknote Edit(int id, [FromBody] Banknote banknote)
        {
            return service.Update(banknote);
        }
        [HttpDelete]
        public string Delete(int id)
        {
            return "delete";
        }
    }
}