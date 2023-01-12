using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;

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
            GameDO gameDO = new GameDO();
            gameDO.Name = entity.Name;
            gameDO.Description = entity.Description;

            entity.Id = repository.Create(gameDO).Id;
            return entity;
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public GameVM Get(int id)
        {
            GameVM gameVM = new GameVM();
            GameDO gameDO = repository.Get(id);
            gameVM.Id = gameDO.Id;
            gameVM.Name = gameDO.Name;
            gameVM.Description = gameDO.Description;
            gameVM.IsCompleted= gameDO.IsCompleted;
            return gameVM;
        }
        public List<GameVM> GetAll(int page, int perPage)
        {
            List<GameDO> gamesDO = repository.GetAll(page, perPage);
            List<GameVM> gamesVM = new List<GameVM>();

            gamesDO.ForEach(gameDO =>
            {
                GameVM gameVM = new GameVM();
                gameVM.Id = gameDO.Id;
                gameVM.Name = gameDO.Name;
                gameVM.Description = gameDO.Description;
                gameVM.IsCompleted = gameDO.IsCompleted;
                gamesVM.Add(gameVM);
            });
            return gamesVM;
            
        }

        public GameVM Update(GameVM entity)
        {
            GameDO gameDO = new GameDO();
            gameDO.Name = entity.Name;
            gameDO.Description = entity.Description;
            gameDO.Id = (long)entity.Id;
            repository.Update(gameDO);
            return entity;
        }
        public int TotalCount()
        {
            return repository.TotalCount();
        }
    }
}
