using Monopoly.Repository.Repositories;
using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Service.Services
{
    public class FieldTypeService
    {
        private FieldTypeRepository repository;
        public FieldTypeService(FieldTypeRepository repository) { 
            this.repository = repository;   
        }

        public FieldType Create(FieldType entity)
        {
            return repository.Create(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public FieldType Get(int id)
        {
            return repository.Get(id);
        }

        public List<FieldType> GetAll()
        {
            return repository.GetAll();
        }

        public FieldType Update(FieldType entity)
        {
            return repository.Update(entity);
        }
        public int Total() { 
            return repository.Total();
        }
    }
}
