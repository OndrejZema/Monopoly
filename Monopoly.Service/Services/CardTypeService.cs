using Monopoly.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Service.ViewModels;
using Monopoly.Repository.DomainObjects;

namespace Monopoly.Service.Services
{
    public class CardTypeService
    {
        private CardTypeRepository repository;
        public CardTypeService(CardTypeRepository repository) { 
            this.repository = repository;
        }
        public CardTypeVM Create(CardTypeVM entity)
        {
            CardTypeDO cardTypeDO = new CardTypeDO();
            cardTypeDO.Name= entity.Name;
            cardTypeDO.Description= entity.Description;
            entity.Id = repository.Create(cardTypeDO).Id;
            return entity;

        }
        public void Delete(int id)
        {
            repository.Delete(id);
        }
        public CardTypeVM Get(int id)
        {
            CardTypeDO cardTypeDO = repository.Get(id);
            CardTypeVM cardTypeVM = new CardTypeVM();
            cardTypeVM.Id = cardTypeDO.Id;
            cardTypeVM.Name = cardTypeDO.Name;
            cardTypeVM.Description = cardTypeDO.Description;

            return cardTypeVM;

        }

        public List<CardTypeVM> GetAll(int page, int perPage)
        {
            List<CardTypeDO> cardTypesDO =  repository.GetAll(page, perPage);
            List<CardTypeVM> cardTypesVM = new List<CardTypeVM>();
            cardTypesDO.ForEach(cardTypeDO =>
            {
                CardTypeVM cardTypeVM = new CardTypeVM();
                cardTypeVM.Id = cardTypeDO.Id;
                cardTypeVM.Name = cardTypeDO.Name;
                cardTypeVM.Description = cardTypeDO.Description;
                cardTypesVM.Add(cardTypeVM);
            });
            return cardTypesVM;
        }
        public CardTypeVM Update(CardTypeVM entity)
        {
            CardTypeDO cardTypeDO = new CardTypeDO();
            cardTypeDO.Name = entity.Name;
            cardTypeDO.Description = entity.Description;
            entity.Id = repository.Update(cardTypeDO).Id;
            return entity;
        }
        public int TotalCount() { 
            return repository.TotalCount();  
        }
    }
}
