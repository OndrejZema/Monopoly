using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.DAL;
using Monopoly.Repository.DomainObjects;

namespace Monopoly.Repository.Repositories
{
    public class FieldTypeRepository : BaseRepository, IRepository<FieldTypeDO>
    {
        public FieldTypeRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public FieldTypeDO Create(FieldTypeDO entity)
        {
            FieldType fieldType = new FieldType();
            fieldType.Name = entity.Name;
            fieldType.Description = entity.Description;

            DbContext.FieldTypes.Add(fieldType);
            DbContext.SaveChanges();
            entity.Id = fieldType.Id;
            return entity;
        }

        public void Delete(int id)
        {
            DbContext.FieldTypes.Remove(DbContext.FieldTypes.ToList().Find(fieldType => fieldType.Id == id));
            DbContext.SaveChanges();
        }

        public FieldTypeDO Get(int id)
        {
            FieldType fieldType = DbContext.FieldTypes.ToList().Find(item => item.Id == id);
            FieldTypeDO fieldTypeDO = new FieldTypeDO();
            fieldTypeDO.Id = fieldType.Id;
            fieldTypeDO.Name = fieldType.Name;  
            fieldTypeDO.Description = fieldType.Description;  
            return fieldTypeDO;
        }
        public List<FieldTypeDO> GetAll(int page, int perPage)
        {
            List<FieldType> fieldTypes = DbContext.FieldTypes.Skip(perPage * page).Take(perPage).ToList();
            List<FieldTypeDO> fieldTypesDO = new List<FieldTypeDO>();
            fieldTypes.ForEach(fieldType =>
            {
                FieldTypeDO fieldTypeDO = new FieldTypeDO();
                fieldTypeDO.Id = fieldType.Id;
                fieldTypeDO.Name = fieldType.Name;
                fieldTypeDO.Description = fieldType.Description;
                fieldTypesDO.Add(fieldTypeDO);
            });
            return fieldTypesDO;
        }

        public FieldTypeDO Update(FieldTypeDO entity)
        {
            FieldType fieldType = new FieldType();
            fieldType.Name = entity.Name;
            fieldType.Description = entity.Description;

            DbContext.FieldTypes.Update(fieldType);
            DbContext.SaveChanges();
            entity.Id = fieldType.Id;
            return entity;
        }
        public int TotalCount()
        {
            return DbContext.FieldTypes.Count();
        }
    }
}
