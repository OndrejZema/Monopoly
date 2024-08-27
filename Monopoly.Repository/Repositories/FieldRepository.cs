using Monopoly.Repository.DomainObjects;
using Monopoly.NewDAL;
using Monopoly.NewDAL.Entities;
using Monopoly.Repository.Exceptions;
using Monopoly.Repository.Utils;

namespace Monopoly.Repository.Repositories
{
    public class FieldRepository : BaseRepository, IRepository<FieldDO>
    {
        public FieldRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public FieldDO Create(FieldDO entity)
        {
            Field field = Converter.FieldDOToField(entity);
            field.Id = null;
            DbContext.Fields.Add(field);
            DbContext.SaveChanges();
            entity.Id = field.Id;
            return entity;
        }

        public void Delete(long id)
        {
            Field? field = DbContext.Fields.Where(field => field.Id == id).FirstOrDefault();
            if(field == null)
            {
                throw new NotFoundRecordException();
            }
            DbContext.Fields.Remove(field);
            DbContext.SaveChanges();
        }

        public FieldDO Get(long id)
        {
            Field? field = DbContext.Fields.Where(item => item.Id == id).FirstOrDefault();
            if (field == null)
            {
                return null;
            }
            FieldType? fieldType = DbContext.FieldTypes.Where(fieldType => fieldType.Id == field.FieldTypeId).FirstOrDefault();
            if (field == null)
            {
                return null;
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
            return GetAll(null, null, null);
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
            else if(gameId != null)
            {
                fields = DbContext.Fields.Where(field => field.GameId == gameId).ToList();
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
        public int TotalCount(long? gameId)
        {
            return gameId == null ? DbContext.Fields.Count() : DbContext.Fields.Where(item => item.GameId == gameId).Count();
        }
    }
}
