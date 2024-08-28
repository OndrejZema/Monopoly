using System.ComponentModel.DataAnnotations;
using Monopoly.Repository.DomainObjects;
using Monopoly.Repository.Repositories;
using Monopoly.Repository.Repositories.Interfaces;
using Monopoly.Service.Helpers;
using Monopoly.Service.Services.Interfaces;
using Monopoly.Service.ViewModels;

namespace Monopoly.Service.Services;

public class AuthService : IAuthService
{
    private IAuthRepository authRepository;
    public AuthService(IAuthRepository authRepository)
    {
        this.authRepository = authRepository;
    }
    
    public string Login(LoginVM login)
    {
        UserDO user = this.authRepository.Login(login.Email, login.Password);
        if (user != null)
        {
            return TokenHelper.GenerateJwt(login.Email, user.Id.ToString());
        }
        else
        {
            throw new Exception("Incorrect credential");
        }
    }

    public void Register(RegisterVM register)
    {
        if (register.Password != register.ConfirmPassword)
        {
            throw new ValidationException();
        }

        if (register.Password.Length < 6)
        {
            throw new ValidationException();
        }
        UserDO user = this.authRepository.Register(register.Email, register.Password);
        
    }
}