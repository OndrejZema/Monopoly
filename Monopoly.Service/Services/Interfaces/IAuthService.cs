using Monopoly.Service.ViewModels;

namespace Monopoly.Service.Services.Interfaces;

public interface IAuthService
{
    public string Login(LoginVM login);
    public void Register(RegisterVM register);
}