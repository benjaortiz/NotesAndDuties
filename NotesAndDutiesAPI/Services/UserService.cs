using NotesAndDutiesAPI.Models;
using Repository.UserRepository;

namespace Services.UserService;

public class UserService : IUserService
{
    private IUserRepository _users;

    public UserService(IUserRepository repo)
    {
        _users = repo;
    }

    public UserModel? getUser(UserLogin user)
    {
        return this._users.getByName(user.Username);
    }

    public UserModel? getUser(UserModel user)
    {
        return this._users.getByName(user.Username);
    }

    public UserModel? addNewUser(UserModelDto newUser)
    {
        UserModel? foundByEmail = this._users.getByEmail(newUser.EmailAddress);
        UserModel? foundByUsername = this._users.getByName(newUser.Username);

        if (foundByEmail != null || foundByUsername != null)
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

        return this._users.addUser(user);
    }
}