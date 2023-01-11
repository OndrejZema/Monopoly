using Monopoly.Repository.Model;
using Monopoly.Repository.Repositories;
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
        private CardRepository cardrepository;
        private FieldRepository fieldRepository;
        private BanknoteRepository banknoteRepository;
        public GamePreviewService(GameRepository gameRepository,
                CardRepository cardrepository,
                FieldRepository fieldRepository,
                BanknoteRepository banknoteRepository
            ) { 
            this.gameRepository = gameRepository;   
            this.cardrepository = cardrepository;   
            this.fieldRepository = fieldRepository; 
            this.banknoteRepository = banknoteRepository;
        }

        public List<GamePreview> GetAll() {
            List<GamePreview> games = new List<GamePreview>();


            return games;
        }
    }
}
