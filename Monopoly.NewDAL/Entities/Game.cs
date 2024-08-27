namespace Monopoly.NewDAL.Entities;

public partial class Game
{
    public long? Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long IsCompleted { get; set; }
    
    public long UserId { get; set; }
    
    public User User { get; set; }
    public ICollection<Banknote> Banknotes { get; set; }
    public ICollection<Field> Fields { get; set; }

    public ICollection<Card> Cards { get; set; }
}
