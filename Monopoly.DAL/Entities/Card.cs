using System;
using System.Collections.Generic;

namespace Monopoly.DAL.Entities;

public partial class Card
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long CardTypeId { get; set; }

    public long GameId { get; set; }
}
