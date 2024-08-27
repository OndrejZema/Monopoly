using Monopoly.NewDAL;

namespace Monopoly.Repository.Repositories
{
    public class BaseRepository
    {
        private ApplicationDbContext dbContext;
        public ApplicationDbContext DbContext
        {
            get { return dbContext; }
        }
        public BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
