using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.DAL;

namespace Monopoly.Repository.Repositories
{
    public class FieldTypeRepository : BaseRepository, IRepository<FieldType>
    {
        public FieldTypeRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public FieldType Create(FieldType entity)
        {
            DbContext.FieldTypes.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            DbContext.FieldTypes.Remove(Get(id));
            DbContext.SaveChanges();
        }

        public FieldType Get(int id)
        {
            return DbContext.FieldTypes.ToList().Find(item => item.Id == id);
        }

        public List<FieldType> GetAll()
        {
            return DbContext.FieldTypes.ToList();
        }

        public FieldType Update(FieldType entity)
        {
            DbContext.FieldTypes.Update(entity);
            DbContext.SaveChanges();
            return entity;
        }
        public int Total()
        {
            return DbContext.FieldTypes.Count();
        }
    }
}
