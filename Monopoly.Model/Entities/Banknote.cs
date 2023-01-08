using System;
using System.Collections.Generic;

namespace Monopoly.Model.Entities;

public partial class Banknote
{
    public long Id { get; set; }

    public long Value { get; set; }

    public long Count { get; set; }

    public string Unit { get; set; }

    public long GameId { get; set; }
}
