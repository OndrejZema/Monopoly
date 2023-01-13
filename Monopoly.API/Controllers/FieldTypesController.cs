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
    public class FieldTypesController : ControllerBase
    {
        private FieldTypeService service;
        public FieldTypesController(FieldTypeService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public List<FieldTypeVM> Index(int page, int perPage)
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
        public FieldTypeVM Details(int id)
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
        public FieldTypeVM Create([FromBody] FieldTypeVM fieldType)
        {
            try
            {
                return service.Create(fieldType);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return null;
            }
        }
        [HttpPut]
        public FieldTypeVM Edit([FromBody] FieldTypeVM fieldType)
        {
            try
            {
                return service.Update(fieldType);
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
