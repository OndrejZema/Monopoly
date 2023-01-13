using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Repository.DomainObjects;
using Monopoly.DAL.Entities;
using Monopoly.DAL;
using Monopoly.Repository.Exceptions;
using Monopoly.Repository.Utils;

namespace Monopoly.Repository.Repositories
{
    public class FieldTypeRepository : BaseRepository, IRepository<FieldTypeDO>
    {
        public FieldTypeRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public FieldTypeDO Create(FieldTypeDO entity)
        {
            FieldType fieldType = Converter.FieldTypeDOToFieldType(entity);

            DbContext.FieldTypes.Add(fieldType);
            DbContext.SaveChanges();
            entity.Id = fieldType.Id;
            return entity;
        }

        public void Delete(int id)
        {
            FieldType? fieldType = DbContext.FieldTypes.Where(fieldType => fieldType.Id == id).FirstOrDefault();
            if (fieldType == null)
            {
                throw new NotFoundRecordException();
            }
            DbContext.FieldTypes.Remove(fieldType);
            DbContext.SaveChanges();
        }

        public FieldTypeDO Get(int id)
        {
            FieldType? fieldType = DbContext.FieldTypes.Where(item => item.Id == id).FirstOrDefault();
            if (fieldType== null)
            {
                throw new NotFoundRecordException();
            }
            FieldTypeDO fieldTypeDO = new FieldTypeDO(fieldType.Id, 
                fieldType.Name, fieldType.Description);
            return fieldTypeDO;
        }
        public List<FieldTypeDO> GetAll(int page, int perPage)
        {
            List<FieldType> fieldTypes = DbContext.FieldTypes.Skip(perPage * page).Take(perPage).ToList();
            List<FieldTypeDO> fieldTypesDO = new List<FieldTypeDO>();
            fieldTypes.ForEach(fieldType =>
            {
                FieldTypeDO fieldTypeDO = new FieldTypeDO(fieldType.Id,
                    fieldType.Name, fieldType.Description);
                fieldTypesDO.Add(fieldTypeDO);
            });
            return fieldTypesDO;
        }

        public FieldTypeDO Update(FieldTypeDO entity)
        {
            FieldType fieldType = Converter.FieldTypeDOToFieldType(entity);

            DbContext.FieldTypes.Update(fieldType);
            DbContext.SaveChanges();
            //entity.Id = fieldType.Id;
            return entity;
        }
        public int TotalCount()
        {
            return DbContext.FieldTypes.Count();
        }
    }
}
