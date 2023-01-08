using Monopoly.Repository.Repositories;
using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Service.Services
{
    public class BanknoteService
    {
        private BanknoteRepository repository;
        public BanknoteService(BanknoteRepository repository) { 
            this.repository = repository;
        }

        public Banknote Create(Banknote entity)
        {
            repository.Create(entity);
            return null;
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Banknote Get(int id)
        {
            return repository.Get(id);
        }

        public List<Banknote> GetAll()
        {
            return repository.GetAll();
        }

        public int Total() { 
            return repository.Total();
        }

        public Banknote Update(Banknote entity)
        {
            throw new NotImplementedException();
        }
    }
}
