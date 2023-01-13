using System;
using System.Collections.Generic;
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
    public class FieldRepository : BaseRepository, IRepository<FieldDO>
    {
        public FieldRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public FieldDO Create(FieldDO entity)
        {
            Field field = Converter.FieldDOToField(entity);
            DbContext.Fields.Add(field);
            DbContext.SaveChanges();
            entity.Id = field.Id;
            return entity;
        }

        public void Delete(int id)
        {
            Field? field = DbContext.Fields.Where(field => field.Id == id).FirstOrDefault();
            if(field == null)
            {
                throw new NotFoundRecordException();
            }
            DbContext.Fields.Remove(field);
            DbContext.SaveChanges();
        }

        public FieldDO Get(int id)
        {
            Field? field = DbContext.Fields.Where(item => item.Id == id).FirstOrDefault();
            if (field == null)
            {
                throw new NotFoundRecordException();
            }
            FieldType? fieldType = DbContext.FieldTypes.Where(fieldType => fieldType.Id == field.FieldTypeId).FirstOrDefault();
            if (field == null)
            {
                throw new NotFoundRecordException();
            }
            FieldTypeDO fieldTypeDO = new FieldTypeDO(fieldType.Id,
                fieldType.Name, fieldType.Description
                );

            FieldDO fieldDO = new FieldDO(field.Id, 
                field.Name, field.Description, fieldTypeDO, field.GameId);

            return fieldDO;
        }
        public List<FieldDO> GetAll()
        {
            List<Field> fields = DbContext.Fields.ToList();
            List<FieldDO> fieldsDO = new List<FieldDO>();
            fields.ForEach(field =>
            {
                FieldType? fieldType = DbContext.FieldTypes.Where(fieldType => fieldType.Id == field.FieldTypeId).FirstOrDefault();
                if (fieldType == null)
                {
                    throw new NotFoundRecordException();
                }
                FieldTypeDO fieldTypeDO = new FieldTypeDO(fieldType.Id,
                     fieldType.Name, fieldType.Description);

                FieldDO fieldDO = new FieldDO(field.Id,
                    field.Name, field.Description, fieldTypeDO, field.GameId);

                fieldsDO.Add(fieldDO);
            });
            return fieldsDO;
        }
        public List<FieldDO> GetAll(int page, int perPage)
        {
            List<Field> fields = DbContext.Fields.Skip(perPage * page).Take(perPage).ToList();
            List<FieldDO> fieldsDO = new List<FieldDO>();
            fields.ForEach(field =>
            {
                FieldType? fieldType = DbContext.FieldTypes.Where(fieldType => fieldType.Id == field.FieldTypeId).FirstOrDefault();
                if (fieldType == null)
                {
                    throw new NotFoundRecordException();
                }
                FieldTypeDO fieldTypeDO = new FieldTypeDO(fieldType.Id,
                     fieldType.Name, fieldType.Description);

                FieldDO fieldDO = new FieldDO(field.Id,
                    field.Name, field.Description, fieldTypeDO, field.GameId);

                fieldsDO.Add(fieldDO);
            });
            return fieldsDO;
        }

        public FieldDO Update(FieldDO entity)
        {
            Field field = Converter.FieldDOToField(entity);
            DbContext.Fields.Update(field);
            DbContext.SaveChanges();
            //entity.Id = field.Id;
            return entity;
        }
        public int TotalCount()
        {
            return DbContext.Fields.Count();
        }
    }
}
