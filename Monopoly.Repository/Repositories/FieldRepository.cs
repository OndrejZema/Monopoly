using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Repository.DomainObjects;
using Monopoly.DAL.Entities;
using Monopoly.DAL;
namespace Monopoly.Repository.Repositories
{
    public class FieldRepository : BaseRepository, IRepository<FieldDO>
    {
        public FieldRepository(MonopolyDbContext dbContext) : base(dbContext)
        {
        }

        public FieldDO Create(FieldDO entity)
        {
            Field field = new Field();
            field.Name = entity.Name;
            field.Description = entity.Description;
            field.FieldTypeId = entity.Type.Id;
            field.GameId = entity.GameId;

            DbContext.Fields.Add(field);
            DbContext.SaveChanges();
            entity.Id = field.Id;
            return entity;
        }

        public void Delete(int id)
        {
            DbContext.Fields.Remove(DbContext.Fields.ToList().Find(field => field.Id == id));
            DbContext.SaveChanges();
        }

        public FieldDO Get(int id)
        {
            FieldDO fieldDO = new FieldDO();
            Field field = DbContext.Fields.ToList().Find(item => item.Id == id);
            FieldType fieldType = DbContext.FieldTypes.ToList().Find(fieldType => fieldType.Id == field.FieldTypeId);
            FieldTypeDO fieldTypeDO = new FieldTypeDO();
            fieldTypeDO.Id = fieldType.Id;
            fieldTypeDO.Name = fieldType.Name;
            fieldTypeDO.Description = fieldType.Description;


            fieldDO.Id = field.Id;
            fieldDO.Name = field.Name;
            fieldDO.Description = field.Description;
            fieldDO.Type = fieldTypeDO;
            fieldDO.GameId = field.GameId;

            return fieldDO;
        }
        public List<FieldDO> GetAll()
        {
            List<Field> fields = DbContext.Fields.ToList();
            List<FieldDO> fieldsDO = new List<FieldDO>();
            fields.ForEach(field =>
            {
                FieldDO fieldDO = new FieldDO();

                FieldType fieldType = DbContext.FieldTypes.ToList().Find(fieldType => fieldType.Id == field.FieldTypeId);
                FieldTypeDO fieldTypeDO = new FieldTypeDO();
                fieldTypeDO.Id = fieldType.Id;
                fieldTypeDO.Name = fieldType.Name;
                fieldTypeDO.Description = fieldType.Description;

                fieldDO.Id = field.Id;
                fieldDO.Name = field.Name;
                fieldDO.Description = field.Description;
                fieldDO.Type = fieldTypeDO;
                fieldDO.GameId = field.GameId;
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
                FieldDO fieldDO = new FieldDO();

                FieldType fieldType = DbContext.FieldTypes.ToList().Find(fieldType => fieldType.Id == field.FieldTypeId);
                FieldTypeDO fieldTypeDO = new FieldTypeDO();
                fieldTypeDO.Id = fieldType.Id;
                fieldTypeDO.Name = fieldType.Name;
                fieldTypeDO.Description = fieldType.Description;

                fieldDO.Id = field.Id;
                fieldDO.Name = field.Name;
                fieldDO.Description = field.Description;
                fieldDO.Type = fieldTypeDO;
                fieldDO.GameId = field.GameId;
                fieldsDO.Add(fieldDO);
            });
            return fieldsDO;
        }

        public FieldDO Update(FieldDO entity)
        {
            Field field = new Field();
            field.Name = entity.Name;
            field.Description = entity.Description;
            field.FieldTypeId = entity.Type.Id;
            field.GameId = entity.GameId;
            DbContext.Fields.Update(field);
            DbContext.SaveChanges();
            entity.Id = field.Id;
            return entity;
        }
        public int TotalCount()
        {
            return DbContext.Fields.Count();
        }
    }
}
