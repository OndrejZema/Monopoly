using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;
using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Exceptions;
using Monopoly.Repository.Repositories.Interfaces;
using Monopoly.Service.Services.Interfaces;

namespace Monopoly.Service.Services
{
    public class FieldTypeService : IFieldTypeService
    {
        private IFieldTypeRepository repository;
        private IFieldRepository fieldRepo;
        public FieldTypeService(IFieldTypeRepository repository, IFieldRepository fieldRepo) { 
            this.repository = repository; 
            this.fieldRepo = fieldRepo;
        }
        
        public FieldTypeVM Create(FieldTypeVM entity)
        {
            FieldTypeDO fieldTypeDO = new FieldTypeDO(entity.Name, entity.Description);
            if (!fieldTypeDO.IsValid())
            {
                throw new ValueException();
            }
            entity.Id = repository.Create(fieldTypeDO).Id;
            return entity;
        }

        public void Delete(int id)
        {
            if (repository.Get(id) == null)
            {
                throw new NotFoundRecordException();
            }
            if(fieldRepo.GetAll().Where(item => item.Type.Id == id).ToList().Count != 0)
            {
                throw new RecordWithDependenciesException();
            }
            repository.Delete(id);
        }

        public FieldTypeVM Get(int id)
        {
            FieldTypeDO fieldTypeDO = repository.Get(id);

            if (fieldTypeDO == null)
            {
                throw new NotFoundRecordException();
            }

            FieldTypeVM fieldTypeVM = new FieldTypeVM(fieldTypeDO.Id, fieldTypeDO.Name, fieldTypeDO.Description);


            return fieldTypeVM;

        }
        public List<FieldTypeVM> GetAll(int? page, int? perPage)
        {
            List<FieldTypeDO> fieldTypesDO = repository.GetAll(page, perPage);
            if (fieldTypesDO == null)
            {
                throw new NotFoundRecordException();
            }
            return fieldTypesDO.Select(fieldTypeDO =>
            {
                return new FieldTypeVM(fieldTypeDO.Id, fieldTypeDO.Name, fieldTypeDO.Description);
            }).ToList();
        }

        public FieldTypeVM Update(FieldTypeVM entity)
        {
            FieldTypeDO fieldTypeDO = new FieldTypeDO(entity.Id, entity.Name, entity.Description);
            if (fieldTypeDO.Id == null)
            {
                throw new NotFoundRecordException();
            }
            //if (repository.Get((long)fieldTypeDO.Id) == null)
            //{
            //    throw new NotFoundRecordException();
            //}
            if (!fieldTypeDO.IsValid())
            {
                throw new ValueException();
            }
            entity.Id = repository.Update(fieldTypeDO).Id;
            return entity;
        }
        public int TotalCount() { 
            return repository.TotalCount();
        }
    }
}
