using Monopoly.DAL;
using Monopoly.DAL.Entities;
using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Exceptions;
using Monopoly.Repository.Utils;
namespace Monopoly.Repository.Repositories
{
    public class CardRepository : BaseRepository, IRepository<CardDO>
    {
        public CardRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public CardDO Create(CardDO entity)
        {
            Card card = Converter.CardDOToCard(entity);

            DbContext.Cards.Add(card);
            DbContext.SaveChanges();
            entity.Id = card.Id;
            return entity;
        }

        public void Delete(int id)
        {
            Card? card = DbContext.Cards.Where(card => card.Id == id).FirstOrDefault();
            if (card == null)
            {
                throw new NotFoundRecordException();
            }
            DbContext.Cards.Remove(card);


            DbContext.SaveChanges();
        }

        public CardDO Get(int id)
        {
            Card? card = DbContext.Cards.Where(item => item.Id == id).FirstOrDefault();
            if (card == null)
            {
                throw new NotFoundRecordException();
            }
            CardType? cardType = DbContext.CardTypes.Where(cardType => cardType.Id == card.CardTypeId).FirstOrDefault();
            if (cardType == null)
            {
                throw new NotFoundRecordException();
            }

            CardTypeDO cardTypeDO = new CardTypeDO(cardType.Id,
                cardType.Name, cardType.Description);

            CardDO cardDO = new CardDO(card.Id,
                card.Name, card.Description,
                cardTypeDO, card.GameId);

            return cardDO;
        }
        public List<CardDO> GetAll(int? gameId, int? page, int? perPage)
        {
            List<Card> cards;
            if(gameId != null && page != null && perPage != null) {
                cards = DbContext.Cards.Where(card => card.GameId == gameId).Skip((int)page * (int)perPage).Take((int)perPage).ToList(); 
            }
            else if(page != null && perPage != null)
            {
                cards = DbContext.Cards.Skip((int)page * (int)perPage).Take((int)perPage).ToList();
            }
            else if(gameId != null)
            {
                cards = DbContext.Cards.Where(card => card.GameId == gameId).ToList();
            }
            else
            {
                cards = DbContext.Cards.ToList();
            }
            return cards.Select(card =>
            {
                CardType? cardType = DbContext.CardTypes.Where(cardType => cardType.Id == card.CardTypeId).FirstOrDefault();
                if (cardType == null)
                {
                    throw new NotFoundRecordException();
                }
                CardTypeDO cardTypeDO = new CardTypeDO(cardType.Id,
                    cardType.Name, cardType.Description);

                return new CardDO(card.Id, card.Name, card.Description, cardTypeDO, card.GameId);
            }).ToList();
        }

        public CardDO Update(CardDO entity)
        {
            Card card = Converter.CardDOToCard(entity);

            DbContext.Cards.Update(card);
            DbContext.SaveChanges();
            //entity.Id = card.Id;
            return entity;
        }
        public int TotalCount(int? gameId)
        {
            return gameId == null ? DbContext.Cards.Count() : DbContext.Cards.Where(item => item.GameId == gameId).Count();
        }
    }
}
