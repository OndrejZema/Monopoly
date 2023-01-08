using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Repository.Model
{
    public class FullBanknote
    {
        public long Id { get; set; }

        public long Value { get; set; }

        public long Count { get; set; }

        public string Unit { get; set; }

        public Game CurrentGame{ get; set; }
    }
}
