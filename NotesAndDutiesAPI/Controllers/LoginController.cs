using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NotesAndDutiesAPI.Models;

namespace NotesAndDutiesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private IConfiguration _config;
    private ILoginService loginService;
    public LoginController(IConfiguration config, ILoginService login)
    {
        _config = config;
        loginService = login;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody] UserLogin loginData)
    {
        var user = this.loginService.AuthenticateUser(loginData);

        if (user != null)
        {
            var token = this.loginService.GenerateJwt(user);
            return Ok(token);
        }

        return NotFound("could not find a valid user/password");
    }

    [AllowAnonymous]
    [HttpPost("/register")]
    public IActionResult Register([FromBody] UserModelDto newUser)
    {
        UserModel? registeredUser = this.loginService.addNewUser(newUser);

        if (registeredUser != null)
        {
            return StatusCode(201);
        }

        return BadRequest("the username/email address is already in use.");
    }
}