using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.DAL;

namespace Monopoly.Repository.Repositories
{
    public class CardRepository : BaseRepository, IRepository<Card>
    {
        public CardRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public Card Create(Card entity)
        {
            DbContext.Cards.Add(entity);
            DbContext.SaveChanges();
            return null;
        }

        public void Delete(int id)
        {
            DbContext.Cards.Remove(Get(id));
            DbContext.SaveChanges();
        }

        public Card Get(int id)
        {
            return DbContext.Cards.ToList().Find(item => item.Id == id);
        }

        public List<Card> GetAll()
        {
            return DbContext.Cards.ToList();
        }

        public Card Update(Card entity)
        {
            throw new NotImplementedException();
        }
    }
}
