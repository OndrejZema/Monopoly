using Monopoly.Repository.Repositories;
using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Service.Services
{
    public class CardTypeService
    {
        private CardTypeRepository repository;
        public CardTypeService(CardTypeRepository repository) { 
            this.repository = repository;
        }
        public CardType Create(CardType entity)
        {
            return repository.Create(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public CardType Get(int id)
        {
            return repository.Get(id);
        }

        public List<CardType> GetAll()
        {
            return repository.GetAll();
        }

        public CardType Update(CardType entity)
        {
            return repository.Update(entity);
        }
        public int Total() { 
            return repository.Total();  
        }
    }
}
