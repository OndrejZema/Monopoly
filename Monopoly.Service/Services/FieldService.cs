using Monopoly.Model.Entities;
using Monopoly.Repository.Repositories;

namespace Monopoly.Service.Services
{
    public class FieldService
    {

        private FieldRepository repository;
        public FieldService(FieldRepository repository)
        {
            this.repository = repository;
        }

        public Field Create(Field entity)
        {
            return repository.Create(entity);
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
            return repository.Update(entity);
        }
        public int Total()
        {
            return repository.Total();
        }
    }
}
