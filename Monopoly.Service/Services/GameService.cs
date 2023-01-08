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
            repository.Create(entity);
            return null;
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

        public Game Update(Game entity)
        {
            throw new NotImplementedException();
        }
    }
}
