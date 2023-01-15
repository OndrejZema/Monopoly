using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Exceptions;
using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;

namespace Monopoly.Service.Services
{
    public class BanknoteService
    {
        private BanknoteRepository repository;
        private GameRepository gameRepo;
        public BanknoteService(BanknoteRepository repository, GameRepository gameRepo)
        {
            this.repository = repository;
            this.gameRepo = gameRepo;
        }

        public BanknoteVM Create(BanknoteVM entity)
        {
            BanknoteDO banknoteDO = new BanknoteDO(entity.Value,
                entity.Count, entity.Unit, entity.GameId);
            if (!banknoteDO.IsValid())
            {
                throw new ValueException();
            }
            if (gameRepo.Get((long)banknoteDO.GameId) == null) {
                throw new NotFoundRecordException();
            }
            entity.Id = repository.Create(banknoteDO).Id;
            return entity;
        }

        public void Delete(int id)
        {
            if(repository.Get(id) == null)
            {
                throw new NotFoundRecordException();
            }
            repository.Delete(id);
        }

        public BanknoteVM Get(int id)
        {
            BanknoteDO banknoteDO = repository.Get(id);
            if (banknoteDO == null)
            {
                throw new NotFoundRecordException();
            }
            BanknoteVM banknoteVM = new BanknoteVM(banknoteDO.Id,
                banknoteDO.Value, banknoteDO.Count, banknoteDO.Unit, banknoteDO.GameId);
            return banknoteVM;
        }

        public List<BanknoteVM> GetAll(int? gameId, int page, int perPage)
        {
            List<BanknoteDO> banknotesDO = repository.GetAll(gameId, page, perPage);
            if (banknotesDO == null)
            {
                throw new NotFoundRecordException();
            }
            return banknotesDO.Select(banknoteDO =>
            {
                return new BanknoteVM(banknoteDO.Id,
                banknoteDO.Value, banknoteDO.Count, banknoteDO.Unit, banknoteDO.GameId);
            }).ToList();
        }

        public BanknoteVM Update(BanknoteVM entity)
        {
            BanknoteDO banknoteDO = new BanknoteDO(entity.Id, 
                entity.Value, entity.Count, entity.Unit, entity.GameId);
            if(!banknoteDO.IsValid())
            {
                throw new ValueException();
            }
            if(gameRepo.Get(banknoteDO.GameId) == null)
            {
                throw new NotFoundRecordException();
            }
            
            entity.Id = repository.Update(banknoteDO).Id;
            return entity;
        }
        public int TotalCount(int? gameId)
        {
            return repository.TotalCount(gameId);
        }
    }
}
