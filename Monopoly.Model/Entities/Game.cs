using System;
using System.Collections.Generic;

namespace Monopoly.Model.Entities;

public partial class Game
{
    public long Id { get; set; }

    public string Name { get; set; }

    public long Complete { get; set; }
}
