using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.DAL;

namespace Monopoly.Repository.Repositories
{
    public class GameRepository : BaseRepository, IRepository<Game>
    {
        public GameRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public Game Create(Game entity)
        {
            DbContext.Games.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            DbContext.Games.Remove(Get(id));
            DbContext.SaveChanges();
        }

        public Game Get(int id)
        {
            return DbContext.Games.ToList().Find(item => item.Id == id);
        }

        public List<Game> GetAll()
        {
            return DbContext.Games.ToList();
        }
        public List<Game> GetAll(int page, int perPage)
        {
            return DbContext.Games.ToList().Skip(perPage*page).Take(perPage).ToList();
        }

        public Game Update(Game entity)
        {
            DbContext.Games.Update(entity);
            DbContext.SaveChanges();
            return entity;
            //return DbContext.Games.ToList().Find(game => game.Id == entity.Id);
        }
        public int Total()
        {
            return DbContext.Games.Count();
        }
    }
}
