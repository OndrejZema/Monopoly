using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Repositories;
using Monopoly.Service.ViewModels;

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
            FieldDO fieldDO = new FieldDO();
            FieldTypeDO fieldTypeDO = new FieldTypeDO();
            fieldTypeDO.Name = entity.Type.Name;
            fieldTypeDO.Description = entity.Type.Description;

            fieldDO.Name = entity.Name; 
            fieldDO.Description = entity.Description;

            
            fieldDO.Type = fieldTypeDO;

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
            FieldVM fieldVM = new FieldVM();
            fieldVM.Name = fieldDO.Name;
            fieldVM.Description = fieldDO.Description;
            fieldVM.GameId = fieldDO.GameId;

            FieldTypeVM fieldTypeVM = new FieldTypeVM();
            fieldTypeVM.Name = fieldDO.Type.Name;
            fieldTypeVM.Description = fieldDO.Type.Description;

            fieldVM.Type = fieldTypeVM;

            return fieldVM;
        }
        public List<FieldVM> GetAll(int page, int perPage)
        {
            List<FieldDO> fieldsDO =  repository.GetAll(page, perPage);
            List<FieldVM> fieldsVM = new List<FieldVM>();

            fieldsDO.ForEach(fieldDO =>
            {
                FieldVM fieldVM = new FieldVM();
                fieldVM.Name = fieldDO.Name;
                fieldVM.Description = fieldDO.Description;
                fieldVM.GameId = fieldDO.GameId;

                FieldTypeVM fieldTypeVM = new FieldTypeVM();
                fieldTypeVM.Name = fieldDO.Type.Name;
                fieldTypeVM.Description = fieldDO.Type.Description;

                fieldVM.Type = fieldTypeVM;

                fieldsVM.Add(fieldVM);
            });

            return fieldsVM;

        }

        public FieldVM Update(FieldVM entity)
        {
            FieldDO fieldDO = new FieldDO();
            FieldTypeDO fieldTypeDO = new FieldTypeDO();
            fieldTypeDO.Name = entity.Type.Name;
            fieldTypeDO.Description = entity.Type.Description;

            fieldDO.Name = entity.Name;
            fieldDO.Description = entity.Description;


            fieldDO.Type = fieldTypeDO;

            entity.Id = repository.Update(fieldDO).Id;
            return entity;
        }
        public int TotalCount()
        {
            return repository.TotalCount();
        }
    }
}
