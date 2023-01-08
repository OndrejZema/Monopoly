using Monopoly.Repository.Repositories;
using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Service.Services
{
    public class CardService
    {
        private CardRepository repository;
        public CardService(CardRepository repository) {
            this.repository = repository;
        }
        public Card Create(Card entity)
        {
            repository.Create(entity);
            return null;
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Card Get(int id)
        {
            return repository.Get(id);
        }

        public List<Card> GetAll()
        {
            return repository.GetAll();
        }

        public Card Update(Card entity)
        {
            throw new NotImplementedException();
        }
    }
}
