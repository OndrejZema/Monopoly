using Monopoly.Repository.Repositories;
using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Service.Services
{
    public class FieldService
    {

        private FieldRepository repository;
        public FieldService(FieldRepository repository) {
            this.repository = repository;
        }

        public Field Create(Field entity)
        {
            repository.Create(entity);
            return null;
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Field Get(int id)
        {
            return repository.Get(id);
        }

        public List<Field> GetAll()
        {
            return repository.GetAll();
        }

        public Field Update(Field entity)
        {
            throw new NotImplementedException();
        }
    }
}
