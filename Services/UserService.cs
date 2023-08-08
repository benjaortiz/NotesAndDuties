using Repository.UserRepository;

namespace Services.UserService;

public class UserService : IUserService {
    private IUserRepository _users;

    public UserService(IUserRepository repo){
        _users = repo;
    }
}