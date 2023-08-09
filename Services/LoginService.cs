using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NotesAndDutiesAPI.Models;

namespace Services.LoginService;

public class LoginService : ILoginService
{
    private IConfiguration _config;
    private IUserRepository users;

    public LoginService(IConfiguration config, IUserRepository usersRepo){
        _config = config;
        users = usersRepo;
    }

    public UserModel AuthenticateUser(UserLogin loginData)
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

    public string GenerateJwt(UserModel user)
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
}