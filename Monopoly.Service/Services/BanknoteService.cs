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
    public class BanknoteService
    {
        private BanknoteRepository repository;
        public BanknoteService(BanknoteRepository repository) { 
            this.repository = repository;
        }

        public BanknoteVM Create(BanknoteVM entity)
        {

            return repository.Create(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public BanknoteVM Get(int id)
        {
            return repository.Get(id);
        }
        public List<BanknoteVM> GetAll()
        {
            return repository.GetAll();
        }

        public List<BanknoteVM> GetAll(int page, int perPage)
        {
            return repository.GetAll(page, perPage);
        }

        public BanknoteVM Update(BanknoteVM entity)
        {
            return repository.Update(entity);
        }
        public int TotalCount() {
            return repository.Total();
        }
    }
}
