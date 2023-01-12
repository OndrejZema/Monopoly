using Monopoly.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Service.ViewModels;
using Monopoly.Repository.DomainObjects;
using Microsoft.VisualBasic.FileIO;

namespace Monopoly.Service.Services
{
    public class FieldTypeService
    {
        private FieldTypeRepository repository;
        public FieldTypeService(FieldTypeRepository repository) { 
            this.repository = repository;   
        }
        
        public FieldTypeVM Create(FieldTypeVM entity)
        {
            FieldTypeDO fieldTypeDO = new FieldTypeDO();
            fieldTypeDO.Name = entity.Name;
            fieldTypeDO.Description = entity.Description;

            entity.Id = repository.Create(fieldTypeDO).Id;
            return entity;
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public FieldTypeVM Get(int id)
        {
            FieldTypeVM fieldTypeVM = new FieldTypeVM();
            FieldTypeDO fieldTypeDO = repository.Get(id);

            fieldTypeVM.Id = fieldTypeDO.Id;
            fieldTypeVM.Name = fieldTypeDO.Name;
            fieldTypeVM.Description = fieldTypeDO.Description;

            return fieldTypeVM;

        }
        public List<FieldTypeVM> GetAll(int page, int perPage)
        {
            List<FieldTypeDO> fieldTypesDO = repository.GetAll(page, perPage);
            List<FieldTypeVM> fieldTypesVM = new List<FieldTypeVM>();
            fieldTypesDO.ForEach(fieldTypeDO =>
            {
                FieldTypeVM fieldTypeVM = new FieldTypeVM();
                fieldTypeVM.Id = fieldTypeDO.Id;
                fieldTypeVM.Name = fieldTypeDO.Name;
                fieldTypeVM.Description = fieldTypeDO.Description;
                fieldTypesVM.Add(fieldTypeVM);
            });
            return fieldTypesVM;

        }

        public FieldTypeVM Update(FieldTypeVM entity)
        {
            FieldTypeDO fieldTypeDO = new FieldTypeDO();
            fieldTypeDO.Name = entity.Name;
            fieldTypeDO.Description = entity.Description;

            entity.Id = repository.Create(fieldTypeDO).Id;

            repository.Update(fieldTypeDO);
            return entity;
        }
        public int TotalCount() { 
            return repository.TotalCount();
        }
    }
}
