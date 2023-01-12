using Monopoly.Repository.Model;
using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Service.Services
{
    public class GamePreviewService
    {
        private GameRepository gameRepository;
        private CardRepository cardRepository;
        private FieldRepository fieldRepository;
        private BanknoteRepository banknoteRepository;
        public GamePreviewService(GameRepository gameRepository,
                CardRepository cardRepository,
                FieldRepository fieldRepository,
                BanknoteRepository banknoteRepository
            ) { 
            this.gameRepository = gameRepository;   
            this.cardRepository = cardRepository;   
            this.fieldRepository = fieldRepository; 
            this.banknoteRepository = banknoteRepository;
        }

        public List<GamePreviewVM> GetAll(int page, int perPage) {
            List<GamePreviewVM> games = gameRepository.GetAll(page, perPage).Select(game =>
            new GamePreviewVM()
            {
                Id= (int)game.Id,
                Name= game.Name,
                IsCompleted = game.IsCompleted == 1?true:false,
                CardsCount = cardRepository.GetAll().Where(card => card.GameId == game.Id).Count(),
                FieldsCount = fieldRepository.GetAll().Where(field => field.GameId == game.Id).Count(),
                BanknotesCount = banknoteRepository.GetAll().Where(banknote => banknote.GameId == game.Id).Count()
            }
            ).ToList();


            return games;
        }
    }
}
