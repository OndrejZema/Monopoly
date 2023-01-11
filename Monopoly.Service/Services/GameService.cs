using Monopoly.Repository.Repositories;
using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Service.Services
{
    public class GameService
    {
        private GameRepository repository;
        public GameService(GameRepository repository) {
            this.repository = repository;
        }

        public Game Create(Game entity)
        {
            return repository.Create(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Game Get(int id)
        {
            return repository.Get(id);
        }

        public List<Game> GetAll()
        {
            return repository.GetAll();
        }
        public List<Game> GetAll(int page, int perPage)
        {
            return repository.GetAll(page, perPage);
        }

        public Game Update(Game entity)
        {
            return repository.Update(entity);
        }
        public int Total() {
            return repository.Total();
        }
    }
}
