using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.DAL;

namespace Monopoly.Repository.Repositories
{
    public class FieldRepository : BaseRepository, IRepository<Field>
    {
        public FieldRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public Field Create(Field entity)
        {
            DbContext.Fields.Add(entity);
            DbContext.SaveChanges();
            return null;
        }

        public void Delete(int id)
        {
            DbContext.Fields.Remove(Get(id));
            DbContext.SaveChanges();
        }

        public Field Get(int id)
        {
            return DbContext.Fields.ToList().Find(item => item.Id == id);
        }

        public List<Field> GetAll()
        {
            return DbContext.Fields.ToList();
        }

        public Field Update(Field entity)
        {
            throw new NotImplementedException();
        }
    }
}
