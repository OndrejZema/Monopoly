using Monopoly.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.DAL;
using Monopoly.Model.Entities;

namespace Monopoly.Repository.Repositories
{
    public class BanknoteRepository : BaseRepository, IRepository<Banknote>
    {
        public BanknoteRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public Banknote Create(Banknote entity)
        {
            DbContext.Banknotes.Add(entity);
            DbContext.SaveChanges();
            return null;
        }

        public void Delete(int id)
        {
            DbContext.Banknotes.Remove(Get(id));
            DbContext.SaveChanges();
        }

        public Banknote Get(int id)
        {
            return DbContext.Banknotes.ToList().Find(item => item.Id == id);
        }

        public List<Banknote> GetAll()
        {
            return DbContext.Banknotes.ToList();
        }

        public Banknote Update(Banknote entity)
        {
            throw new NotImplementedException();
        }
        public int Total() {
            return DbContext.Banknotes.Count();
        }
    }
}
