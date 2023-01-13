using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;
using Monopoly.Repository.Exceptions;
using Monopoly.DAL.Entities;

namespace Monopoly.Service.Services
{
    public class GameService
    {
        private GameRepository repository;
        public GameService(GameRepository repository)
        {
            this.repository = repository;
        }

        public GameVM Create(GameVM entity)
        {
            GameDO gameDO = new GameDO(entity.Id, entity.Name, entity.Description, entity.IsCompleted);

            entity.Id = repository.Create(gameDO).Id;
            return entity;
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public GameVM Get(int id)
        {
            GameDO gameDO = repository.Get(id);
            if (gameDO == null)
            {
                throw new NotFoundRecordException();
            }
            GameVM gameVM = new GameVM(gameDO.Id, gameDO.Name, gameDO.Description, gameDO.IsCompleted);

            return gameVM;
        }
        public List<GameVM> GetAll(int page, int perPage)
        {
            List<GameDO> gamesDO = repository.GetAll(page, perPage);
            if (gamesDO == null)
            {
                throw new NotFoundRecordException();
            }

            return gamesDO.Select(gameDO =>
            {
                return new GameVM((long)gameDO.Id, gameDO.Name, gameDO.Description, gameDO.IsCompleted);
            }).ToList();            
        }

        public GameVM Update(GameVM entity)
        {
            GameDO gameDO = new GameDO(entity.Id, entity.Name, entity.Description, entity.IsCompleted);
            repository.Update(gameDO);
            return entity;
        }
        public int TotalCount()
        {
            return repository.TotalCount();
        }
    }
}
