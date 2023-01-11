using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Repository.Model
{
    public class GamePreview
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int CardsCount { get; set; }
        public int FieldsCount { get; set; }
        public int BanknotesCount { get; set; }
        public long Complete { get; set; }
    }
}
