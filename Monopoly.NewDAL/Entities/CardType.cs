namespace Monopoly.NewDAL.Entities;

public partial class CardType
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public ICollection<Card> Cards { get; set; }
    
    
}
