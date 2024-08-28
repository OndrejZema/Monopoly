using Monopoly.NewDAL;
using Monopoly.NewDAL.Entities;
using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Exceptions;
using Monopoly.Repository.Repositories.Interfaces;
using Monopoly.Repository.Utils;

namespace Monopoly.Repository.Repositories
{
    public class BanknoteRepository : BaseRepository, IBanknoteRepository
    {
        public BanknoteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public BanknoteDO Create(BanknoteDO entity)
        {
            Banknote banknote = Converter.BanknoteDOToBanknote(entity);
            banknote.Id = null;
            DbContext.Banknotes.Add(banknote);
            DbContext.SaveChanges();
            entity.Id = banknote.Id;
            return entity;
        }

        public void Delete(long id)
        {
            Banknote? banknote = DbContext.Banknotes.Where(banknote => banknote.Id == id).FirstOrDefault();
            if (banknote == null)
            {
                throw new NotFoundRecordException();
            }
            DbContext.Banknotes.Remove(banknote);
            DbContext.SaveChanges();
        }

        public BanknoteDO Get(long id)
        {
            Banknote? banknote = DbContext.Banknotes.Where(banknote => banknote.Id == id).FirstOrDefault();
            if (banknote == null)
            {
                return null;
            }
            BanknoteDO banknoteDO = new BanknoteDO(banknote.Id,
                banknote.Value, banknote.Count,
                banknote.Unit, banknote.GameId);
            return banknoteDO;
        }
        public List<BanknoteDO> GetAll()
        {
            return GetAll(null, null, null);
        }
        public List<BanknoteDO> GetAll(int? gameId, int? page, int? perPage)
        {

            List<Banknote> banknotes;
            if (gameId != null && page != null && perPage != null)
            {
                banknotes = DbContext.Banknotes.Where(banknotes => banknotes.GameId == gameId).Skip((int)page * (int)perPage).Take((int)perPage).ToList();
            }
            else if (page != null && perPage != null)
            {
                banknotes = DbContext.Banknotes.Skip((int)page * (int)perPage).Take((int)perPage).ToList();
            }
            else if(gameId != null)
            {
                banknotes = DbContext.Banknotes.Where(banknotes => banknotes.GameId == gameId).ToList();
            }
            else
            {
                banknotes = DbContext.Banknotes.ToList();
            }
            return banknotes.Select(banknote =>
            {
                return new BanknoteDO(banknote.Id, banknote.Value, banknote.Count,
                    banknote.Unit, banknote.GameId);
            }).ToList();
        }

        public BanknoteDO Update(BanknoteDO entity)
        {
            Banknote banknote = Converter.BanknoteDOToBanknote(entity);
            DbContext.Banknotes.Update(banknote);
            DbContext.SaveChanges();
            //entity.Id = banknote.Id;
            return entity;
        }
        public int TotalCount(long? gameId)
        {
            return gameId == null? DbContext.Banknotes.Count():DbContext.Banknotes.Where(item => item.GameId == gameId).Count();
        }
    }
}
