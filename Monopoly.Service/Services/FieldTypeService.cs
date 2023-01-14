using Monopoly.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Service.ViewModels;
using Monopoly.Repository.DomainObjects;
using Microsoft.VisualBasic.FileIO;
using Monopoly.Repository.Exceptions;
using Monopoly.DAL.Entities;

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
            FieldTypeDO fieldTypeDO = new FieldTypeDO(entity.Id, entity.Name, entity.Description);

            entity.Id = repository.Create(fieldTypeDO).Id;
            return entity;
        }

        public void Delete(int id)
        {
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

            entity.Id = repository.Update(fieldTypeDO).Id;
            return entity;
        }
        public int TotalCount() { 
            return repository.TotalCount();
        }
    }
}
