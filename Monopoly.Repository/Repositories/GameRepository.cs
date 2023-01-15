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
            game.Id = null;
            DbContext.Games.Add(game);
            DbContext.SaveChanges();
            entity.Id = game.Id;
            return entity;
        }

        public void Delete(long id)
        {
            Game? game = DbContext.Games.Where(game => game.Id == id).FirstOrDefault();
            if (game == null) {
                throw new NotFoundRecordException();
            }
            int cards = DbContext.Cards.Where(card => card.GameId == id).ToList().Count;
            int fields= DbContext.Fields.Where(field => field.GameId == id).ToList().Count;
            int banknotes = DbContext.Banknotes.Where(banknote => banknote.GameId == id).ToList().Count;
            if(cards != 0 || fields != 0 || banknotes != 0)
            {
                throw new RecordWithDependenciesException();
            }

            DbContext.Games.Remove(game);
            DbContext.SaveChanges();
        }

        public GameDO Get(long id)
        {
            Game? game = DbContext.Games.Where(item => item.Id == id).FirstOrDefault();
            if (game == null)
            {
                return null;
            }
            GameDO gameDO = new GameDO(game.Id, game.Name, game.Description, game.IsCompleted);
            return gameDO;
        }

        public List<GameDO> GetAll() {
            return GetAll(null, null);
        }
        public List<GameDO> GetAll(int? page, int? perPage)
        {
            List<Game> games;
            if (page != null && perPage != null){
                games = DbContext.Games.Skip((int)perPage * (int)page).Take((int)perPage).ToList();
            }
            else
            {
                games = DbContext.Games.ToList();
            }
            
            return games.Select(game =>
            {
                return new GameDO(game.Id, game.Name, game.Description, game.IsCompleted);
            }).ToList();
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
