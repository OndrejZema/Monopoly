using Monopoly.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Repository.Model;

namespace Monopoly.Service.Services
{
    public class FieldFullService
    {
        private FieldRepository fielsRepository;
        private FieldTypeRepository fieldTypeRepository;
        private GameRepository gameRepository;
        public FieldFullService(FieldRepository fieldRepository, 
            FieldTypeRepository fieldTypeRepository, 
            GameRepository gameRepository) {
            this.fielsRepository = fieldRepository; 
            this.fieldTypeRepository = fieldTypeRepository; 
            this.gameRepository = gameRepository;   
        }

        public List<FieldFull> GetAll() {

            List<FieldFull> fields = new List<FieldFull>();


            return fields;
        }
    }
}
