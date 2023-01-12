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
    public class CardTypeService
    {
        private CardTypeRepository repository;
        public CardTypeService(CardTypeRepository repository) { 
            this.repository = repository;
        }
        public CardTypeVM Create(CardTypeVM entity)
        {
            return repository.Create(entity);
        }
        public void Delete(int id)
        {
            repository.Delete(id);
        }
        public CardTypeVM Get(int id)
        {
            return repository.Get(id);
        }
        public List<CardTypeVM> GetAll()
        {
            return repository.GetAll();
        }

        public List<CardTypeVM> GetAll(int page, int perPage)
        {
            return repository.GetAll(page, perPage);
        }
        public CardTypeVM Update(CardTypeVM entity)
        {
            return repository.Update(entity);
        }
        public int Total() { 
            return repository.Total();  
        }
    }
}
