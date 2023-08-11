using NotesAndDutiesAPI.Models;
using Repository.UserRepository;

namespace Services.UserService;

public class UserService : IUserService {
    private IUserRepository _users;

    public UserService(IUserRepository repo){
        _users = repo;
    }

    public UserModel getUser(UserLogin user)
    {
        return this._users.getByName(user.Username);
    }

    public UserModel getUser(UserModel user)
    {
        return this._users.getByName(user.Username);
    }
}