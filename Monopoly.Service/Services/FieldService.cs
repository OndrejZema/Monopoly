using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;
using Monopoly.Repository.Exceptions;
using Monopoly.Repository.Repositories.Interfaces;
using Monopoly.Service.Services.Interfaces;

namespace Monopoly.Service.Services
{
    public class FieldService : IFieldService
    {

        private IFieldRepository repository;
        private IFieldTypeRepository fieldTypeRepo;
        private IGameRepository gameRepo;
        public FieldService(IFieldRepository repository, IFieldTypeRepository fieldTypeRepo, IGameRepository gameRepo)
        {
            this.repository = repository;
            this.fieldTypeRepo = fieldTypeRepo;
            this.gameRepo = gameRepo;
        }

        public FieldVM Create(FieldVM entity)
        {
            FieldTypeDO fieldTypeDO = new FieldTypeDO(entity.Type.Id, entity.Type.Name, entity.Type.Description);


            FieldDO fieldDO = new FieldDO(entity.Name, entity.Description, fieldTypeDO, entity.GameId);

            if (!fieldDO.IsValid())
            {
                throw new ValueException();
            }
            if(fieldTypeRepo.Get((long)fieldDO.Type.Id) == null || gameRepo.Get(fieldDO.GameId) == null)
            {
                throw new NotFoundRecordException();
            }

            entity.Id = repository.Create(fieldDO).Id;
            return entity;
        }

        public void Delete(int id)
        {
            if(repository.Get(id) == null)
            {
                throw new NotFoundRecordException();
            }
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
            if (fieldDO.Id == null)
            {
                throw new NotFoundRecordException();
            }
            //if (repository.Get((long)fieldDO.Id) == null)
            //{
            //    throw new NotFoundRecordException();
            //}
            if (!fieldDO.IsValid())
            {
                throw new ValueException();
            }
            if (fieldTypeRepo.Get((long)fieldDO.Type.Id) == null || gameRepo.Get(fieldDO.GameId) == null)
            {
                throw new NotFoundRecordException();
            }

            entity.Id = repository.Update(fieldDO).Id;
            return entity;
        }
        public int TotalCount(int? gameId)
        {
            return repository.TotalCount(gameId);
        }
    }
}
