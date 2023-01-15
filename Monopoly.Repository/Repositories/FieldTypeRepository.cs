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
            int fields = DbContext.Fields.Where(field => field.FieldTypeId == id).ToList().Count;
            if(fields != 0)
            {
                throw new RecordWithDependenciesException();
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
        public List<FieldTypeDO> GetAll(int? page, int? perPage)
        {
            List<FieldType> fieldTypes;
            if (page != null && perPage != null)
            {
                fieldTypes = DbContext.FieldTypes.Skip((int)perPage * (int)page).Take((int)perPage).ToList();
            }
            else
            {
                fieldTypes = DbContext.FieldTypes.ToList();
            }
            return fieldTypes.Select(fieldType =>
            {
                return new FieldTypeDO(fieldType.Id, fieldType.Name, fieldType.Description);
            }).ToList();
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
