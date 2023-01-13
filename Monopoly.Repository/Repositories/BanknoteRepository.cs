using Monopoly.DAL;
using Monopoly.DAL.Entities;
using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Exceptions;
using Monopoly.Repository.Utils;

namespace Monopoly.Repository.Repositories
{
    public class BanknoteRepository : BaseRepository, IRepository<BanknoteDO>
    {
        public BanknoteRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public BanknoteDO Create(BanknoteDO entity)
        {
            Banknote banknote = Converter.BanknoteDOToBanknote(entity);
            DbContext.Banknotes.Add(banknote);
            DbContext.SaveChanges();
            entity.Id = banknote.Id;
            return entity;
        }

        public void Delete(int id)
        {
            Banknote? banknote = DbContext.Banknotes.Where(banknote => banknote.Id == id).FirstOrDefault();
            if (banknote == null)
            {
                throw new NotFoundRecordException();
            }
            DbContext.Banknotes.Remove(banknote);
            DbContext.SaveChanges();
        }

        public BanknoteDO Get(int id)
        {
            Banknote? banknote = DbContext.Banknotes.Where(banknote => banknote.Id == id).FirstOrDefault();
            if (banknote == null)
            {
                throw new NotFoundRecordException();
            }
            BanknoteDO banknoteDO = new BanknoteDO(banknote.Id,
                banknote.Value, banknote.Count,
                banknote.Unit, banknote.GameId);
            return banknoteDO;
        }
        public List<BanknoteDO> GetAll()
        {
            List<Banknote> banknotes = DbContext.Banknotes.ToList();
            List<BanknoteDO> banknotesDO = new List<BanknoteDO>();
            banknotes.ForEach(banknote =>
            {
                BanknoteDO banknoteDO = new BanknoteDO(banknote.Id,
                        banknote.Value, banknote.Count,
                        banknote.Unit, banknote.GameId);
                banknotesDO.Add(banknoteDO);

            });
            return banknotesDO;
        }
        public List<BanknoteDO> GetAll(int page, int perPage)
        {
            List<Banknote> banknotes = DbContext.Banknotes.Skip(perPage * page).Take(perPage).ToList();
            List<BanknoteDO> banknotesDO = new List<BanknoteDO>();
            banknotes.ForEach(banknote =>
            {
                BanknoteDO banknoteDO = new BanknoteDO(banknote.Id,
                    banknote.Value, banknote.Count,
                    banknote.Unit, banknote.GameId);

                banknotesDO.Add(banknoteDO);

            });
            return banknotesDO;
        }

        public BanknoteDO Update(BanknoteDO entity)
        {
            Banknote banknote = Converter.BanknoteDOToBanknote(entity);
            DbContext.Banknotes.Update(banknote);
            DbContext.SaveChanges();
            //entity.Id = banknote.Id;
            return entity;
        }
        public int TotalCount()
        {
            return DbContext.Banknotes.Count();
        }
    }
}
