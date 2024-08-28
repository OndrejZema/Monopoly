using Monopoly.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Service.ViewModels;
using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Exceptions;
using Monopoly.Repository.Repositories.Interfaces;
using Monopoly.Service.Services.Interfaces;

namespace Monopoly.Service.Services
{
    public class CardTypeService : ICardTypeService
    {
        private ICardTypeRepository repository;
        private ICardRepository cardRepo;
        public CardTypeService(ICardTypeRepository repository, ICardRepository cardRepo) { 
            this.repository = repository;
            this.cardRepo = cardRepo;
        }
        public CardTypeVM Create(CardTypeVM entity)
        {
            CardTypeDO cardTypeDO = new CardTypeDO(entity.Name, entity.Description);
            if (!cardTypeDO.IsValid()) {
                throw new ValueException();
            }

            entity.Id = repository.Create(cardTypeDO).Id;
            return entity;

        }
        public void Delete(int id)
        {
            if(repository.Get(id) == null)
            {
                throw new NotFoundRecordException();
            }
            if(cardRepo.GetAll().Where(item => item.Type.Id == id).ToList().Count != 0)
            {
                throw new RecordWithDependenciesException();
            }
            repository.Delete(id);
        }
        public CardTypeVM Get(int id)
        {
            CardTypeDO cardTypeDO = repository.Get(id);
            if(cardTypeDO == null) {
                throw new NotFoundRecordException();
            }
            CardTypeVM cardTypeVM = new CardTypeVM(cardTypeDO.Id, cardTypeDO.Name, cardTypeDO.Description);

            return cardTypeVM;

        }

        public List<CardTypeVM> GetAll(int? page, int? perPage)
        {
            List<CardTypeDO> cardTypesDO =  repository.GetAll(page, perPage);
            if (cardTypesDO == null)
            {
                throw new NotFoundRecordException();
            }
            return cardTypesDO.Select(cardTypeDO =>
            {
                return new CardTypeVM(cardTypeDO.Id, cardTypeDO.Name, cardTypeDO.Description);
            }).ToList();
        }
        public CardTypeVM Update(CardTypeVM entity)
        {
            CardTypeDO cardTypeDO = new CardTypeDO(entity.Id, entity.Name, entity.Description);
            if(cardTypeDO.Id == null)
            {
                throw new NotFoundRecordException();
            }
            //if(repository.Get((long)cardTypeDO.Id) == null)
            //{
            //    throw new NotFoundRecordException();
            //}   
            if (!cardTypeDO.IsValid())
            {
                throw new ValueException();
            }

            entity.Id = repository.Update(cardTypeDO).Id;
            return entity;
        }
        public int TotalCount() { 
            return repository.TotalCount();  
        }
    }
}
