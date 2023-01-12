using Monopoly.Repository.Repositories;
using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Service.ViewModels;

namespace Monopoly.Service.Services
{
    public class FieldTypeService
    {
        private FieldTypeRepository repository;
        public FieldTypeService(FieldTypeRepository repository) { 
            this.repository = repository;   
        }
        
        public FieldTypeVM Create(FieldTypeVM entity)
        {
            return repository.Create(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public FieldTypeVM Get(int id)
        {
            return repository.Get(id);
        }
        public List<FieldTypeVM> GetAll()
        {
            return repository.GetAll();
        }
        public List<FieldTypeVM> GetAll(int page, int perPage)
        {
            return repository.GetAll();
        }

        public FieldTypeVM Update(FieldTypeVM entity)
        {
            return repository.Update(entity);
        }
        public int Total() { 
            return repository.Total();
        }
    }
}
