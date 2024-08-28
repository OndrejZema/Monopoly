using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;
using Monopoly.Repository.Exceptions;
using Monopoly.Repository.Repositories.Interfaces;
using Monopoly.Service.Services.Interfaces;

namespace Monopoly.Service.Services
{
    public class GameService : IGameService
    {
        private IGameRepository repository;
        private ICardRepository cardRepo;
        private IFieldRepository fieldRepo;
        private IBanknoteRepository banknoteRepo;
        public GameService(IGameRepository repository, ICardRepository cardRepo, IFieldRepository fieldRepo, IBanknoteRepository banknoteRepo)
        {
            this.repository = repository;
            this.cardRepo = cardRepo;
            this.fieldRepo = fieldRepo;
            this.banknoteRepo = banknoteRepo;
        }

        public GameVM Create(GameVM entity)
        {
            GameDO gameDO = new GameDO(entity.Name, entity.Description, entity.IsCompleted);
            if (!gameDO.IsValid())
            {
                throw new ValueException();
            }
            entity.Id = repository.Create(gameDO).Id;
            return entity;
        }

        public void Delete(int id)
        {
            if(repository.Get(id) == null)
            {
                throw new NotFoundRecordException();
            }

            int c = fieldRepo.GetAll().Where(item => item.GameId == id).ToList().Count;
            int a = cardRepo.GetAll().Where(item => item.GameId == id).ToList().Count;
            int b = banknoteRepo.GetAll().Where(item => item.GameId == id).ToList().Count;
          



            if (cardRepo.GetAll().Where(item => item.GameId == id).ToList().Count != 0 ||
                fieldRepo.GetAll().Where(item => item.GameId == id).ToList().Count != 0 ||
                banknoteRepo.GetAll().Where(item => item.GameId == id).ToList().Count != 0)
            {
                throw new RecordWithDependenciesException();
            }

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
            if (!gameDO.IsValid())
            {
                throw new ValueException();
            }
            repository.Update(gameDO);
            return entity;
        }
        public int TotalCount()
        {
            return repository.TotalCount();
        }
    }
}
