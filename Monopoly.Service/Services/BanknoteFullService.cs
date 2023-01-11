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
    public class BanknoteFullService
    {

        private BanknoteRepository banknoteRepository;

        private GameRepository gameRepository;
        public BanknoteFullService(BanknoteRepository banknoteRepository, GameRepository gameRepository)
        {
            this.banknoteRepository = banknoteRepository;
            this.gameRepository = gameRepository;
        }

        public BanknoteFull Get(int id)
        {

            return null;
        }

        public List<BanknoteFull> GetAll()
        {
            return null;
        }
    }
}
