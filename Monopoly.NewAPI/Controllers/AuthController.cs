using Microsoft.AspNetCore.Mvc;
using Monopoly.Service.Services;
using Monopoly.Service.Services.Interfaces;
using Monopoly.Service.ViewModels;

namespace Monopoly.NewAPI.Controllers;
[Route("/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private IAuthService authService;
    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }
    // GET
    [HttpPost("/login")]
    public IActionResult Login([FromBody] LoginVM login)
    {
       try
       {
            return Ok(authService.Login(login));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpPost("/register")]
    public IActionResult Register([FromBody] RegisterVM register)
    {
        try
        {
            authService.Register(register);
            return Ok();
        }
        catch (Exception exception)
        {
            return NotFound();
        }
    }
}