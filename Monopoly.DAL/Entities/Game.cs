using System;
using System.Collections.Generic;

namespace Monopoly.DAL.Entities;

public partial class Game
{
    public long? Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long IsCompleted { get; set; }
}
