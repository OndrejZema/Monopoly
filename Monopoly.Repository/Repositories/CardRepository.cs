using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.DAL;
using Monopoly.Repository.DomainObjects;

namespace Monopoly.Repository.Repositories
{
    public class CardRepository : BaseRepository, IRepository<CardDO>
    {
        public CardRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public CardDO Create(CardDO entity)
        {
            Card card = new Card();
            card.Name = entity.Name;
            card.Description = entity.Description;
            card.CardTypeId = entity.Type.Id;
            card.GameId = entity.Game.Id;

            DbContext.Cards.Add(card);
            DbContext.SaveChanges();
            entity.Id = card.Id;
            return entity;
        }

        public void Delete(int id)
        {
            DbContext.Cards.Remove(DbContext.Cards.ToList().Find(card => card.Id == id));
            DbContext.SaveChanges();
        }

        public CardDO Get(int id)
        {
            CardDO cardDO = new CardDO();
            Card card = DbContext.Cards.ToList().Find(item => item.Id == id);
            CardType cardType = DbContext.CardTypes.ToList().Find(cardType => cardType.Id == card.CardTypeId);
            CardTypeDO cardTypeDO = new CardTypeDO();
            cardTypeDO.Id = card.Id;
            cardTypeDO.Name = card.Name;
            cardTypeDO.Description = card.Description;

            
            Game game = DbContext.Games.ToList().Find(game => game.Id == card.GameId);
            GameDO gameDO= new GameDO();
            gameDO.Id = game.Id;
            gameDO.Name = game.Name;    
            gameDO.Description = game.Description;
            gameDO.IsCompleted = game.IsComplete == 1 ? true : false;

            cardDO.Id = card.Id;
            cardDO.Name = card.Name;
            cardDO.Description = card.Description;
            cardDO.Type = cardTypeDO;
            cardDO.Game = gameDO;

            return cardDO;
        }

        public List<CardDO> GetAll(int page, int perPage)
        {
            List<Card> cards = DbContext.Cards.Skip(perPage * page).Take(perPage).ToList();
            List<CardDO> cardsDO = new List<CardDO>();
            cards.ForEach(card =>
            {
                CardDO cardDO = new CardDO();
                CardType cardType = DbContext.CardTypes.ToList().Find(cardType => cardType.Id == card.CardTypeId);
                CardTypeDO cardTypeDO = new CardTypeDO();
                cardTypeDO.Id = card.Id;
                cardTypeDO.Name = card.Name;
                cardTypeDO.Description = card.Description;


                Game game = DbContext.Games.ToList().Find(game => game.Id == card.GameId);
                GameDO gameDO = new GameDO();
                gameDO.Id = game.Id;
                gameDO.Name = game.Name;
                gameDO.Description = game.Description;
                gameDO.IsCompleted = game.IsComplete == 1 ? true : false;

                cardDO.Id = card.Id;
                cardDO.Name = card.Name;
                cardDO.Description = card.Description;
                cardDO.Type = cardTypeDO;
                cardDO.Game = gameDO;
                cardsDO.Add(cardDO);
            });
            return cardsDO;
        }

        public CardDO Update(CardDO entity)
        {
            Card card = new Card();
            card.Name = entity.Name;
            card.Description = entity.Description;
            card.CardTypeId = entity.Type.Id;
            card.GameId = entity.Game.Id;

            DbContext.Cards.Update(card);
            DbContext.SaveChanges();
            entity.Id = card.Id;
            return entity;
        }
        public int TotalCount()
        {
            return DbContext.Cards.Count();
        }
    }
}
