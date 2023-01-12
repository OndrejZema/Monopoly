using Monopoly.Model.Entities;
using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;

namespace Monopoly.Service.Services
{
    public class FieldService
    {

        private FieldRepository repository;
        public FieldService(FieldRepository repository)
        {
            this.repository = repository;
        }

        public FieldVM Create(FieldVM entity)
        {
            return repository.Create(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public FieldVM Get(int id)
        {
            return repository.Get(id);
        }
        public List<FieldVM> GetAll()
        {
            return repository.GetAll();
        }
        public List<FieldVM> GetAll(int page, int perPage)
        {
            return repository.GetAll(page, perPage);
        }

        public FieldVM Update(FieldVM entity)
        {
            return repository.Update(entity);
        }
        public int TotalCount()
        {
            return repository.Total();
        }
    }
}
