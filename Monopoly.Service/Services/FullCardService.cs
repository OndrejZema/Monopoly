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
    public class FullCardService
    {

        private CardRepository cardRepository;

        private GameRepository gameRepository;
        public FullCardService(CardRepository cardRepository, GameRepository gameRepository)
        {
            this.cardRepository= cardRepository;
            this.gameRepository = gameRepository;
        }

        public FullCard Get(int id)
        {
            FullCard fullCard = new FullCard();
            Card card = cardRepository.Get(id);
            fullCard.Id = card.Id;
            fullCard.Name = card.Name;
            fullCard.Description = card.Description;
            fullCard.CurrentGame = gameRepository.GetAll().Find(game => game.Id == card.GameId);
            return fullCard;
        }

        public List<FullCard> GetAll()
        {
            List<FullCard> fullCards = new List<FullCard>();
            List<Game> games = gameRepository.GetAll();
            foreach (Card card in cardRepository.GetAll()) {
                FullCard fullCard = new FullCard();
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
