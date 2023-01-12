using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.DAL;
using Monopoly.Repository.DomainObjects;

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
            field.GameId = entity.Game.Id;

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


            Game game = DbContext.Games.ToList().Find(game => game.Id == field.GameId);
            GameDO gameDO = new GameDO();
            gameDO.Id = game.Id;
            gameDO.Name = game.Name;
            gameDO.Description = game.Description;
            gameDO.IsCompleted = game.IsComplete == 1 ? true : false;

            fieldDO.Id = field.Id;
            fieldDO.Name = field.Name;
            fieldDO.Description = field.Description;
            fieldDO.Type = fieldTypeDO;
            fieldDO.Game = gameDO;

            return fieldDO;
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


                Game game = DbContext.Games.ToList().Find(game => game.Id == field.GameId);
                GameDO gameDO = new GameDO();
                gameDO.Id = game.Id;
                gameDO.Name = game.Name;
                gameDO.Description = game.Description;
                gameDO.IsCompleted = game.IsComplete == 1 ? true : false;

                fieldDO.Id = field.Id;
                fieldDO.Name = field.Name;
                fieldDO.Description = field.Description;
                fieldDO.Type = fieldTypeDO;
                fieldDO.Game = gameDO;
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
            field.GameId = entity.Game.Id;
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
