using Monopoly.DAL;
using Monopoly.Model.Entities;
using Monopoly.Repository.DomainObjects;

namespace Monopoly.Repository.Repositories
{
    public class CardTypeRepository : BaseRepository, IRepository<CardTypeDO>
    {
        public CardTypeRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public CardTypeDO Create(CardTypeDO entity)
        {
            CardType cardType = new CardType();
            cardType.Name = entity.Name;
            cardType.Description = entity.Description;

            DbContext.CardTypes.Add(cardType);
            DbContext.SaveChanges();
            entity.Id = cardType.Id;
            return entity;
        }

        public void Delete(int id)
        {
            DbContext.CardTypes.Remove(DbContext.CardTypes.ToList().Find(cardType => cardType.Id == id));
            DbContext.SaveChanges();
        }

        public CardTypeDO Get(int id)
        {
            CardType cardType = DbContext.CardTypes.ToList().Find(item => item.Id == id);
            CardTypeDO cardTypeDO = new CardTypeDO();
            cardTypeDO.Name = cardType.Name;
            cardTypeDO.Description = cardType.Description;
            return cardTypeDO;
        }

        public List<CardTypeDO> GetAll(int page, int perPage)
        {

            List<CardType> cardTypes = DbContext.CardTypes.Skip(perPage * page).Take(perPage).ToList();
            List<CardTypeDO> cardTypesDO = new List<CardTypeDO>();
            cardTypes.ForEach(cardType =>
            {
                CardTypeDO cardTypeDO = new CardTypeDO();
                cardTypeDO.Name = cardType.Name;
                cardTypeDO.Description = cardType.Description;
                cardTypesDO.Add(cardTypeDO);
            });
            return cardTypesDO;

        }

        public CardTypeDO Update(CardTypeDO entity)
        {
            CardType cardType = new CardType();
            cardType.Name = entity.Name;
            cardType.Description = entity.Description;
            DbContext.CardTypes.Update(cardType);
            DbContext.SaveChanges();
            entity.Id = cardType.Id;
            return entity;
        }
        public int TotalCount()
        {
            return DbContext.FieldTypes.Count();
        }
    }
}
