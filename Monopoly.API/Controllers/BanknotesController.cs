﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monopoly.Repository.Repositories;
using Monopoly.Service.Services;
using System.Collections.Generic;
using System.Linq;
using Monopoly.Service.ViewModels;
using Monopoly.Repository.Exceptions;
using System;

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
        [HttpGet]
        public ActionResult<List<BanknoteVM>> Index(int page, int perPage)
        {
            Response.Headers.Add("X-Total-Count", service.TotalCount().ToString());
            try
            {
                return Ok(service.GetAll(page, perPage));
            }
            catch(NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public ActionResult<BanknoteVM> Details(int id)
        {
            try
            {
                return Ok(service.Get(id));
            }
            catch(NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult<BanknoteVM> Create([FromBody]BanknoteVM banknote)
        {
            return Ok(service.Create(banknote));
        }
        [HttpPut]
        public ActionResult<BanknoteVM> Edit([FromBody] BanknoteVM banknote)
        {
            try
            {
                return Ok(service.Update(banknote));
            }
            catch(Exception ex) {
                return NotFound();
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                return Ok();
            }
            catch(NotFoundRecordException ex)
            {
                return NotFound();
            }
        }
    }
}
