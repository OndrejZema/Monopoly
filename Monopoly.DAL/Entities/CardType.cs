using System;
using System.Collections.Generic;

namespace Monopoly.DAL.Entities;

public partial class CardType
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
