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
        public List<FieldDO> GetAll(int? gameId, int? page, int? perPage)
        {
            List<Field> fields;
            if (gameId != null && page != null && perPage != null)
            {
                fields = DbContext.Fields.Where(field=> field.GameId == gameId).Skip((int)page * (int)perPage).Take((int)perPage).ToList();
            }
            else if (page != null && perPage != null)
            {
                fields = DbContext.Fields.Skip((int)page * (int)perPage).Take((int)perPage).ToList();
            }
            else
            {
                fields = DbContext.Fields.ToList();
            }
            return fields.Select(field =>
            {
                FieldType? fieldType = DbContext.FieldTypes.Where(fieldType => fieldType.Id == field.FieldTypeId).FirstOrDefault();
                if (fieldType == null)
                {
                    throw new NotFoundRecordException();
                }
                FieldTypeDO fieldTypeDO = new FieldTypeDO(fieldType.Id,
                     fieldType.Name, fieldType.Description);

                return new FieldDO(field.Id,
                    field.Name, field.Description, fieldTypeDO, field.GameId);

            }).ToList();
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
