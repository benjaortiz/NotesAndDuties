using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NotesAndDutiesAPI.Models;

namespace Services.LoginService;

public class LoginService : ILoginService
{
    private IConfiguration _config;
    private ILoginRepository users;

    public LoginService(IConfiguration config, ILoginRepository loginRepo)
    {
        _config = config;
        users = loginRepo;
    }

    public UserModel? addNewUser(UserModelDto newUser)
    {
        List<UserModel> usersList = this.users.GetUserModels();
        bool foundByEmail = false;
        bool foundByUsername = false;
        foreach (UserModel currentUser in usersList)
        {
            if (currentUser.EmailAddress.ToLower().Equals(newUser.EmailAddress.ToLower()))
            {
                foundByEmail = true;
                break;
            }
            if (currentUser.Username.ToLower().Equals(newUser.Username.ToLower()))
            {
                foundByUsername = true;
                break;
            }
        }

        if (foundByEmail || foundByUsername)
        {
            //if anyone is different from null it means the email or username
            //is already registered on the db.
            return null;
        }

        UserModel user = new UserModel
        {
            Username = newUser.Username,
            Password = newUser.Password,
            EmailAddress = newUser.EmailAddress,
            Role = newUser.Role
        };

        return this.users.addUser(user);

    }

    public UserModel? AuthenticateUser(UserLogin loginData)
    {
        var currentUser = this.users.GetUser(loginData);

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
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(JwtRegisteredClaimNames.Aud, _config["Jwt:Audience"]),
            new Claim(JwtRegisteredClaimNames.Iss, _config["Jwt:Issuer"])
        };

        var token = new JwtSecurityToken(
            issuer: this._config["jwt:Issuer"],
            audience: this._config["jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}