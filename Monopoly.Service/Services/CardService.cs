using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Repository.DomainObjects;

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
            CardDO cardDO = new CardDO();

            CardTypeDO cardTypeDO = new CardTypeDO();
            cardTypeDO.Name = entity.Type.Name;
            cardTypeDO.Description = entity.Type.Description;

            cardDO.Name = entity.Name;
            cardDO.Description = entity.Description;
            cardDO.GameId = entity.GameId;
            cardDO.Type = cardTypeDO;
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
            CardTypeVM cardTypeVM= new CardTypeVM();
            cardTypeVM.Id= cardDO.Type.Id;
            cardTypeVM.Name = cardDO.Type.Name;
            cardTypeVM.Description= cardDO.Type.Description;

            CardVM cardVM= new CardVM();
            cardVM.Id = cardDO.Id;
            cardVM.Name = cardDO.Name;
            cardVM.Description = cardDO.Description;
            cardVM.GameId = cardDO.GameId;
            cardVM.Type= cardTypeVM;
            return cardVM;
        }

        public List<CardVM> GetAll(int page, int perPage)
        {
            List<CardDO> cardsDO =  repository.GetAll(page, perPage);
            List<CardVM> cardsVM = new List<CardVM>();
            cardsDO.ForEach(cardDO =>
            {
                CardTypeVM cardTypeVM = new CardTypeVM();
                cardTypeVM.Id = cardDO.Type.Id;
                cardTypeVM.Name = cardDO.Type.Name;
                cardTypeVM.Description = cardDO.Type.Description;

                CardVM cardVM = new CardVM();
                cardVM.Id = cardDO.Id;
                cardVM.Name = cardDO.Name;
                cardVM.Description = cardDO.Description;
                cardVM.GameId = cardDO.GameId;
                cardVM.Type = cardTypeVM;
                cardsVM.Add(cardVM);
            });
            return cardsVM;

        }

        public CardVM Update(CardVM entity)
        {
            CardDO cardDO = new CardDO();

            CardTypeDO cardTypeDO = new CardTypeDO();
            cardTypeDO.Id = (long)entity.Type.Id;
            cardTypeDO.Name = entity.Type.Name;
            cardTypeDO.Description = entity.Type.Description;
            
            cardDO.Name = entity.Name;
            cardDO.Description = entity.Description;
            cardDO.GameId = entity.GameId;
            cardDO.Type = cardTypeDO;


            repository.Update(cardDO);
            entity.Id = repository.Create(cardDO).Id;
            return entity;
        }
        public int TotalCount() { 
            return repository.TotalCount();  
        }
    }
}
