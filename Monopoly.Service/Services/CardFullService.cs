using Monopoly.Repository.Model;
using Monopoly.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Model.Entities;

namespace Monopoly.Service.Services
{
    public class CardFullService
    {

        private CardRepository cardRepository;

        private GameRepository gameRepository;
        public CardFullService(CardRepository cardRepository, GameRepository gameRepository)
        {
            this.cardRepository= cardRepository;
            this.gameRepository = gameRepository;
        }

        public CardFull Get(int id)
        {
            CardFull fullCard = new CardFull();
            Card card = cardRepository.Get(id);
            fullCard.Id = card.Id;
            fullCard.Name = card.Name;
            fullCard.Description = card.Description;
            fullCard.CurrentGame = gameRepository.GetAll().Find(game => game.Id == card.GameId);
            return fullCard;
        }

        public List<CardFull> GetAll()
        {
            List<CardFull> fullCards = new List<CardFull>();
            List<Game> games = gameRepository.GetAll();
            foreach (Card card in cardRepository.GetAll()) {
                CardFull fullCard = new CardFull();
                fullCard.Id = card.Id;
                fullCard.Name = card.Name;
                fullCard.Description = card.Description;
                fullCard.CurrentGame = games.Find(game => game.Id == card.GameId);
                fullCards.Add(fullCard);
            }
            return fullCards;
        }
    }
}
