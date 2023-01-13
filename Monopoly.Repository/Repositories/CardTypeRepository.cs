using Monopoly.DAL.Entities;
using Monopoly.Repository.DomainObjects;
using Monopoly.DAL;
using Monopoly.Repository.Exceptions;
using Monopoly.Repository.Utils;

namespace Monopoly.Repository.Repositories
{
    public class CardTypeRepository : BaseRepository, IRepository<CardTypeDO>
    {
        public CardTypeRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public CardTypeDO Create(CardTypeDO entity)
        {
            CardType cardType = Converter.CardTypeDOToCardType(entity);

            DbContext.CardTypes.Add(cardType);
            DbContext.SaveChanges();
            entity.Id = cardType.Id;
            return entity;
        }

        public void Delete(int id)
        {   CardType? cardType = DbContext.CardTypes.Where(cardType => cardType.Id == id).FirstOrDefault();
            if (cardType == null)
            {
                throw new NotFoundRecordException();
            }
            DbContext.CardTypes.Remove(cardType);
            DbContext.SaveChanges();
        }

        public CardTypeDO Get(int id)
        {
            CardType? cardType = DbContext.CardTypes.Where(item => item.Id == id).FirstOrDefault();
            if (cardType == null)
            {
                throw new NotFoundRecordException();
            }
            CardTypeDO cardTypeDO = new CardTypeDO(cardType.Id, cardType.Name, cardType.Description);

            return cardTypeDO;
        }

        public List<CardTypeDO> GetAll(int page, int perPage)
        {

            List<CardType> cardTypes = DbContext.CardTypes.Skip(perPage * page).Take(perPage).ToList();
            return cardTypes.Select(cardType =>
            {
                return new CardTypeDO(cardType.Id, cardType.Name, cardType.Description);
            }).ToList();

        }

        public CardTypeDO Update(CardTypeDO entity)
        {
            CardType cardType = Converter.CardTypeDOToCardType(entity);
            DbContext.CardTypes.Update(cardType);
            DbContext.SaveChanges();
            //entity.Id = cardType.Id;
            return entity;
        }
        public int TotalCount()
        {
            return DbContext.FieldTypes.Count();
        }
    }
}
