using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.DAL;
namespace Monopoly.Repository.Repositories
{
    public class BaseRepository
    {
        private MonopolyDbContext dbContext;
        public MonopolyDbContext DbContext
        {
            get { return dbContext; }
        }
        public BaseRepository(MonopolyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
