using Monopoly.NewDAL.Entities;

namespace Monopoly.Repository.DomainObjects;

public class UserDO
{
    public long? Id { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<Game> Games { get; set; }
    
    public UserDO()
    {
    }
}