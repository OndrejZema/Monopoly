using Monopoly.NewDAL;
using Monopoly.NewDAL.Entities;
using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Helpers;
using Monopoly.Repository.Repositories.Interfaces;

namespace Monopoly.Repository.Repositories;

public class AuthRepository : BaseRepository, IAuthRepository
{
    public AuthRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public UserDO Login(string email, string password)
    {
        User user = DbContext.Users
            .Where(x => x.Email == email).FirstOrDefault();
        if (user == null)
        {
            return null;
        }

        if (!PasswordHelper.VerifyPassword(password, user.PasswordHash))
        {
            return null;
        }
        UserDO userDO = new UserDO()
        {
            Email = user.Email,
            Id = user.Id
        };
        return userDO;
    }

    public UserDO Register(string email, string password)
    {
        User existUser = DbContext.Users.Where(x => x.Email == email).FirstOrDefault();
        if (existUser != null)
        {
            throw new Exception("Email is already using");
        }

        User user = new User()
        {
            Email = email,
            PasswordHash = PasswordHelper.HashPassword(password)
        };

        DbContext.Add(user);
        DbContext.SaveChanges();
        UserDO userDO = new UserDO()
        {
            Email = user.Email,
            Id = user.Id
        };
        return userDO;
    }
}