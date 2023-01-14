using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;
using Monopoly.Repository.Exceptions;
using Monopoly.DAL.Entities;

namespace Monopoly.Service.Services
{
    public class FieldService
    {

        private FieldRepository repository;
        public FieldService(FieldRepository repository)
        {
            this.repository = repository;
        }

        public FieldVM Create(FieldVM entity)
        {
            FieldTypeDO fieldTypeDO = new FieldTypeDO(entity.Type.Id, entity.Type.Name, entity.Type.Description);


            FieldDO fieldDO = new FieldDO(entity.Name, entity.Description, fieldTypeDO, entity.GameId);

            entity.Id = repository.Create(fieldDO).Id;
            return entity;
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public FieldVM Get(int id)
        {
            FieldDO fieldDO = repository.Get(id);
            if (fieldDO == null)
            {
                throw new NotFoundRecordException();
            }
            FieldTypeVM fieldTypeVM = new FieldTypeVM(fieldDO.Type.Id, fieldDO.Type.Name, fieldDO.Type.Description);

            FieldVM fieldVM = new FieldVM(fieldDO.Id, fieldDO.Name, fieldDO.Description, fieldTypeVM, fieldDO.GameId);


            return fieldVM;
        }
        public List<FieldVM> GetAll(int? gameId, int page, int perPage)
        {
            List<FieldDO> fieldsDO =  repository.GetAll(gameId, page, perPage);
            if (fieldsDO== null)
            {
                throw new NotFoundRecordException();
            }

            return fieldsDO.Select(fieldDO =>
            {
                FieldTypeVM fieldTypeVM = new FieldTypeVM(fieldDO.Type.Id, fieldDO.Type.Name, fieldDO.Type.Description);

                return new FieldVM(fieldDO.Id, fieldDO.Name, fieldDO.Description, fieldTypeVM, fieldDO.GameId);

             }).ToList();


        }

        public FieldVM Update(FieldVM entity)
        {

            FieldTypeDO fieldTypeDO = new FieldTypeDO(entity.Type.Id, entity.Type.Name, entity.Type.Description);
            FieldDO fieldDO = new FieldDO(entity.Id, entity.Name, entity.Description, fieldTypeDO, entity.GameId);

            entity.Id = repository.Update(fieldDO).Id;
            return entity;
        }
        public int TotalCount()
        {
            return repository.TotalCount();
        }
    }
}
