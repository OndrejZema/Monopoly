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
    public class FieldsController : ControllerBase
    {
        private FieldService service;
        public FieldsController(FieldService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public List<FieldVM> Index(int page, int perPage)
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
        public FieldVM Details(int id)
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
        public FieldVM Create([FromBody] FieldVM field)
        {
            try
            {
                return service.Create(field);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return null;
            }
        }
        [HttpPut]
        public FieldVM Edit([FromBody] FieldVM field)
        {
            try
            {
                return service.Update(field);
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
