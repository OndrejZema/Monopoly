using Monopoly.DAL.Entities;
using Monopoly.Repository.DomainObjects;
using Monopoly.DAL;
using Monopoly.Repository.Exceptions;
using Monopoly.Repository.Utils;

namespace Monopoly.Repository.Repositories
{
    public class GameRepository : BaseRepository, IRepository<GameDO>
    {
        public GameRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public GameDO Create(GameDO entity)
        {
            Game game = Converter.GameDOToGame(entity);
            DbContext.Games.Add(game);
            DbContext.SaveChanges();
            entity.Id = game.Id;
            return entity;
        }

        public void Delete(int id)
        {
            Game? game = DbContext.Games.Where(game => game.Id == id).FirstOrDefault();
            if (game == null) {
                throw new NotFoundRecordException();
            }
            DbContext.Games.Remove(game);
            DbContext.SaveChanges();
        }

        public GameDO Get(int id)
        {
            Game? game = DbContext.Games.Where(item => item.Id == id).FirstOrDefault();
            if (game == null)
            {
                throw new NotFoundRecordException();
            }
            GameDO gameDO = new GameDO(game.Id, game.Name, game.Description, game.IsCompleted);
            return gameDO;
        }

        public List<GameDO> GetAll(int page, int perPage)
        {
            List<Game> games = DbContext.Games.ToList().Skip(perPage * page).Take(perPage).ToList();
            List<GameDO> gamesDO = new List<GameDO>();
            games.ForEach(game =>
            {
                GameDO gameDO = new GameDO(game.Id, game.Name, game.Description, game.IsCompleted);
                gamesDO.Add(gameDO);
            });
            return gamesDO;
        }

        public GameDO Update(GameDO entity)
        {
            Game game = Converter.GameDOToGame(entity);
            DbContext.Games.Update(game);
            DbContext.SaveChanges();
            //entity.Id = game.Id;
            return entity;
        }
        public int TotalCount()
        {
            return DbContext.Games.Count();
        }
    }
}
