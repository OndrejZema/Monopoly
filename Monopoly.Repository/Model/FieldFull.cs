using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Repository.Model
{
    public class FieldFull
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public FieldType Type { get; set; }

        public Game GameId { get; set; }
    }
}
