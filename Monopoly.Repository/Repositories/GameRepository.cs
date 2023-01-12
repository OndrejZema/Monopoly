using Monopoly.DAL.Entities;
using Monopoly.Repository.DomainObjects;
using Monopoly.DAL;
namespace Monopoly.Repository.Repositories
{
    public class GameRepository : BaseRepository, IRepository<GameDO>
    {
        public GameRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public GameDO Create(GameDO entity)
        {
            Game game = new Game();
            game.Name = entity.Name;
            game.Description = entity.Description;

            DbContext.Games.Add(game);
            DbContext.SaveChanges();
            entity.Id = game.Id;
            return entity;
        }

        public void Delete(int id)
        {
            DbContext.Games.Remove(DbContext.Games.ToList().Find(game => game.Id == id));
            DbContext.SaveChanges();
        }

        public GameDO Get(int id)
        {
            Game game = DbContext.Games.ToList().Find(item => item.Id == id);
            GameDO gameDO = new GameDO();
            gameDO.Id = game.Id;
            gameDO.Name = game.Name;
            gameDO.Description = game.Description;
            return gameDO;
        }

        public List<GameDO> GetAll(int page, int perPage)
        {
            List<Game> games = DbContext.Games.ToList().Skip(perPage * page).Take(perPage).ToList();
            List<GameDO> gamesDO = new List<GameDO>();
            games.ForEach(game =>
            {
                GameDO gameDO = new GameDO();
                gameDO.Id = game.Id;
                gameDO.Name = game.Name;
                gameDO.Description = game.Description;
                gamesDO.Add(gameDO);
            });
            return gamesDO;
        }

        public GameDO Update(GameDO entity)
        {
            Game game = new Game();
            game.Name = entity.Name;
            game.Description = entity.Description;
            DbContext.Games.Update(game);
            DbContext.SaveChanges();
            entity.Id = game.Id;
            return entity;
        }
        public int TotalCount()
        {
            return DbContext.Games.Count();
        }
    }
}
