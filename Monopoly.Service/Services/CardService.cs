using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Exceptions;

namespace Monopoly.Service.Services
{
    public class CardService
    {
        private CardRepository repository;
        public CardService(CardRepository repository)
        {
            this.repository = repository;
        }
        public CardVM Create(CardVM entity)
        {
            

            CardTypeDO cardTypeDO = new CardTypeDO(entity.Type.Id, entity.Type.Name, entity.Type.Description);

            CardDO cardDO = new CardDO(entity.Name, entity.Description, cardTypeDO, entity.GameId);

            entity.Id = repository.Create(cardDO).Id;
            return entity;
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public CardVM Get(int id)
        {
            CardDO cardDO = repository.Get(id);
            if (cardDO == null) {
                throw new NotFoundRecordException();
            }
            CardTypeVM cardTypeVM= new CardTypeVM(cardDO.Type.Id, cardDO.Type.Name, cardDO.Type.Description);

            CardVM cardVM= new CardVM(cardDO.Id, cardDO.Name, cardDO.Description, cardTypeVM, cardDO.GameId);
            return cardVM;
        }
        public List<CardVM> GetAll(int? gameId, int page, int perPage)
        {
            List<CardDO> cardsDO = repository.GetAll(gameId, page, perPage);
            if(cardsDO == null)
            {
                throw new NotFoundRecordException();
            }
            return cardsDO.Select(cardDO =>
            {
                CardTypeVM cardTypeVM = new CardTypeVM(cardDO.Type.Id, cardDO.Type.Name, cardDO.Type.Description);
                return  new CardVM(cardDO.Id, cardDO.Name, cardDO.Description, cardTypeVM, cardDO.GameId);
            }).ToList();

        }

        public CardVM Update(CardVM entity)
        {
            CardTypeDO cardTypeDO = new CardTypeDO(entity.Type.Id, entity.Type.Name, entity.Type.Description);

            CardDO cardDO = new CardDO(entity.Name, entity.Description, cardTypeDO, entity.GameId);

            entity.Id = repository.Update(cardDO).Id;
            return entity;
        }
        public int TotalCount() { 
            return repository.TotalCount();  
        }
    }
}
