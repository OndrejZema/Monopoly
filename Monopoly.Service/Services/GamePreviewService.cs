using Monopoly.DAL.Entities;
using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Exceptions;
using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;

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
            )
        {
            this.gameRepository = gameRepository;
            this.cardRepository = cardRepository;
            this.fieldRepository = fieldRepository;
            this.banknoteRepository = banknoteRepository;
        }

        public List<GamePreviewVM> GetAll(int page, int perPage)
        {
            List<GameDO> games = gameRepository.GetAll(page, perPage);
            if (games == null)
            {
                throw new NotFoundRecordException();
            }
            return games.Select(game =>
            new GamePreviewVM((long)game.Id,
            game.Name,
            game.Description,
            game.IsCompleted,
            cardRepository.GetAll((int)game.Id, null, null).Count(),
            fieldRepository.GetAll((int)game.Id, null, null).Count(),
            banknoteRepository.GetAll((int)game.Id, null, null).Count())
            ).ToList();
        }
    }
}
