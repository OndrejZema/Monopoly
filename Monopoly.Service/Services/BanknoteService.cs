using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;

namespace Monopoly.Service.Services
{
    public class BanknoteService
    {
        private BanknoteRepository repository;
        public BanknoteService(BanknoteRepository repository)
        {
            this.repository = repository;
        }

        public BanknoteVM Create(BanknoteVM entity)
        {
            BanknoteDO banknoteDO = new BanknoteDO();
            banknoteDO.Unit = entity.Unit;
            banknoteDO.Value = entity.Value;
            banknoteDO.Count = entity.Count;
            entity.Id = repository.Create(banknoteDO).Id;
            return entity;
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public BanknoteVM Get(int id)
        {
            BanknoteDO banknoteDO = repository.Get(id);
            BanknoteVM banknoteVM = new BanknoteVM();
            banknoteVM.Id = banknoteDO.Id;
            banknoteVM.Value = banknoteDO.Value;
            banknoteVM.Count = banknoteDO.Count;
            banknoteVM.Unit = banknoteDO.Unit;
            return banknoteVM;
        }

        public List<BanknoteVM> GetAll(int page, int perPage)
        {
            List<BanknoteDO> banknotesDO = repository.GetAll(page, perPage);
            List<BanknoteVM> banknotesVM = new List<BanknoteVM>();
            banknotesDO.ForEach(banknoteDO =>
            {
                BanknoteVM banknoteVM = new BanknoteVM();
                banknoteVM.Id = banknoteDO.Id;
                banknoteVM.Value = banknoteDO.Value;
                banknoteVM.Count = banknoteDO.Count;
                banknoteVM.Unit = banknoteDO.Unit;
                banknotesVM.Add(banknoteVM);
            });
            return banknotesVM;
        }

        public BanknoteVM Update(BanknoteVM entity)
        {
            BanknoteDO banknoteDO = new BanknoteDO();
            banknoteDO.Id = (long)entity.Id;
            banknoteDO.Unit = entity.Unit;
            banknoteDO.Value = entity.Value;
            banknoteDO.Count = entity.Count;
            entity.Id = repository.Update(banknoteDO).Id;
            return entity;
        }
        public int TotalCount()
        {
            return repository.TotalCount();
        }
    }
}
