using Monopoly.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Repository.Model
{
    public class FullCard
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Type { get; set; }

        public Game CurrentGame { get; set; }
    }
}
