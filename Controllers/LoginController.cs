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
    public IActionResult Login( [FromBody] UserLogin loginData)
    {
        var user = this.loginService.AuthenticateUser(loginData);

        if (user != null)
        {
            var token = this.loginService.GenerateJwt(user);
            return Ok(token);
        }

        return NotFound("could not find a valid user/password");
    }

    private string Generate(UserModel user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._config["jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[] 
        {
            new Claim(ClaimTypes.NameIdentifier, user.Username),
            new Claim(ClaimTypes.Email, user.EmailAddress),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var token = new JwtSecurityToken(
            this._config["jwt:Issuer"],
            this._config["jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private UserModel AuthenticateUser(UserLogin loginData)
    {
        var currentUser = UserConstants.Users.FirstOrDefault(i => i.Username.ToLower() == loginData.Username.ToLower()
        && i.Password == loginData.Password);

        if (currentUser != null)
        {
            return currentUser;
        }
        else
        {
            return null;
        }
    }
}