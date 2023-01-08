using Monopoly.Model.Entities;
using Monopoly.Repository.Model;
using Monopoly.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Service.Services
{
    public class FullBanknoteService
    {

        private BanknoteRepository banknoteRepository;

        private GameRepository gameRepository;
        public FullBanknoteService(BanknoteRepository banknoteRepository, GameRepository gameRepository)
        {
            this.banknoteRepository = banknoteRepository;
            this.gameRepository = gameRepository;
        }

        public FullBanknote Get(int id)
        {

            return null;
        }

        public List<FullBanknote> GetAll()
        {
            return null;
        }
    }
}
