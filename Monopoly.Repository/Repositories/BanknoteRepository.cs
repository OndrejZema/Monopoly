using Monopoly.DAL;
using Monopoly.Model.Entities;
using Monopoly.Repository.DomainObjects;
namespace Monopoly.Repository.Repositories
{
    public class BanknoteRepository : BaseRepository, IRepository<BanknoteDO>
    {
        public BanknoteRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public BanknoteDO Create(BanknoteDO entity)
        {
            Banknote banknote = new Banknote();
            banknote.Unit = entity.Unit;
            banknote.Value = entity.Value;
            banknote.Count = entity.Count;
            banknote.GameId = entity.Game.Id;
            DbContext.Banknotes.Add(banknote);
            DbContext.SaveChanges();
            entity.Id = banknote.Id;
            return entity;
        }

        public void Delete(int id)
        {
            DbContext.Banknotes.Remove(DbContext.Banknotes.ToList().Find(banknote => banknote.Id == id));
            DbContext.SaveChanges();
        }

        public BanknoteDO Get(int id)
        {
            BanknoteDO banknoteDO = new BanknoteDO();
            Banknote banknote = DbContext.Banknotes.ToList().Find(banknote => banknote.Id == id);

            Game game = DbContext.Games.ToList().Find(game => game.Id == banknote.GameId);
            GameDO gameDO = new GameDO();
            gameDO.Id = game.Id;
            gameDO.Name = game.Name;
            gameDO.Description = game.Description;

            banknoteDO.Id = banknote.Id;
            banknoteDO.Value = banknote.Value;
            banknoteDO.Count = banknote.Count;
            banknoteDO.Unit = banknote.Unit;
            banknoteDO.Game = gameDO;

            return banknoteDO;
        }
        public List<BanknoteDO> GetAll(int page, int perPage)
        {
            List<Banknote> banknotes = DbContext.Banknotes.Skip(perPage * page).Take(perPage).ToList();
            List<BanknoteDO> banknotesDO = new List<BanknoteDO>();
            banknotes.ForEach(banknote =>
            {
                BanknoteDO banknoteDO = new BanknoteDO();
                Game game = DbContext.Games.ToList().Find(game => game.Id == banknote.GameId);
                GameDO gameDO = new GameDO();
                gameDO.Id = game.Id;
                gameDO.Name = game.Name;
                gameDO.Description = game.Description;

                banknoteDO.Id = banknote.Id;
                banknoteDO.Value = banknote.Value;
                banknoteDO.Count = banknote.Count;
                banknoteDO.Unit = banknote.Unit;
                banknoteDO.Game = gameDO;

                banknotesDO.Add(banknoteDO);

            });
            return banknotesDO;
        }

        public BanknoteDO Update(BanknoteDO entity)
        {
            Banknote banknote = new Banknote();
            banknote.Unit = entity.Unit;
            banknote.Value = entity.Value;
            banknote.Count = entity.Count;
            banknote.GameId = entity.Game.Id;
            DbContext.Banknotes.Add(banknote);
            DbContext.SaveChanges();
            entity.Id = banknote.Id;

            DbContext.Banknotes.Update(banknote);
            DbContext.SaveChanges();
            entity.Id = banknote.Id;
            return entity;
        }
        public int TotalCount()
        {
            return DbContext.Banknotes.Count();
        }
    }
}
