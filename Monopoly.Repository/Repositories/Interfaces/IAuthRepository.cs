using Monopoly.Repository.DomainObjects;

namespace Monopoly.Repository.Repositories.Interfaces;

public interface IAuthRepository
{
    public UserDO Login(string email, string password);

    public UserDO Register(string email, string password);
}