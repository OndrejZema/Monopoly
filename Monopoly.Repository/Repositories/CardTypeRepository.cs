using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.DAL;

namespace Monopoly.Repository.Repositories
{
    public class CardTypeRepository : BaseRepository, IRepository<CardType>
    {
        public CardTypeRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public CardType Create(CardType entity)
        {
            DbContext.CardTypes.Add(entity);
            DbContext.SaveChanges();
            return null;
        }

        public void Delete(int id)
        {
            DbContext.CardTypes.Remove(Get(id));
            DbContext.SaveChanges();
        }

        public CardType Get(int id)
        {
            return DbContext.CardTypes.ToList().Find(item => item.Id == id);
        }

        public List<CardType> GetAll()
        {
            return DbContext.CardTypes.ToList();
        }

        public CardType Update(CardType entity)
        {
            throw new NotImplementedException();
        }
    }
}
