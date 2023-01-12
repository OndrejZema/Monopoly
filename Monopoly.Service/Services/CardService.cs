using Monopoly.Repository.Repositories;
using Monopoly.Repository.Model;
using Monopoly.Service.ViewModels;
using Monopoly.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Service.Services
{
    public class CardService
    {
        private CardRepository cardRepo;
        private GameRepository gameRepo;
        public CardService(CardRepository cardRepo, GameRepository gameRepo)
        {
            this.cardRepo = cardRepo;
            this.gameRepo = gameRepo;
        }
        public CardVM Create(CardVM entity)
        {
            return cardRepo.Create(entity);
        }

        public void Delete(int id)
        {
            cardRepo.Delete(id);
        }

        public CardVM Get(int id)
        {
            CardDO card = new CardDO();
            Model.Entities.Card cardDTO = cardRepo.Get(id);
            card.Id = card.Id;
            card.Name = card.Name;
            card.Description = card.Description;
            card.Game = gameRepo.GetAll().Find(game => game.Id == cardDTO.GameId);
            return card;
        }
        public List<CardVM> GetAll()
        {

            List<CardVM> fullCards = new List<CardDO>();
            List<GameDO> games = gameRepository.GetAll();
            foreach (Model.Entities.Card card in cardRepository.GetAll())
            {
                CardDO fullCard = new CardDO();
                fullCard.Id = card.Id;
                fullCard.Name = card.Name;
                fullCard.Description = card.Description;
                fullCard.CurrentGame = games.Find(game => game.Id == card.GameId);
                fullCards.Add(fullCard);
            }
            return fullCards;

            return repository.GetAll();
        }
        public List<CardVM> GetAll(int page, int perPage)
        {
            return cardRepo.GetAll(page, perPage);
        }

        public CardVM Update(CardVM entity)
        {
            return cardRepo.Update(entity);
        }
        public int TotalCount() { 
            return cardRepo.Total();  
        }
    }
}
