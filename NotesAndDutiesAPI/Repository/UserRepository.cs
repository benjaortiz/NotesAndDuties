using NotesAndDutiesAPI;
using NotesAndDutiesAPI.Models;

namespace Repository.UserRepository;

public class UserRepository : IUserRepository, ILoginRepository
{
    private AppDbContext _users;

    public UserRepository(AppDbContext db)
    {
        _users = db;
    }

    public List<UserModel> GetUserModels()
    {
        return this._users.Set<UserModel>().ToList();
    }

    public UserModel? getById(int id)
    {

        var query = from u in _users.users
                    where u.UserId == id
                    select u;

        return query.FirstOrDefault();
    }

    public UserModel? getByName(string username)
    {
        
        var query = from u in _users.users
                    where u.Username.Equals(username)
                    select u;
        
        return query.FirstOrDefault();
    }

    public UserModel? addUser(UserModel newUser)
    {
        this._users.users.Add(newUser);
        this._users.SaveChanges();

        return this.getByName(newUser.Username);
    }

    public UserModel? GetUser(UserLogin userData)
    {
        var query = from u in _users.users
                    where u.Username.Equals(userData.Username) && u.Password.Equals(userData.Password)
                    select u;

        return query.FirstOrDefault();
    }

    public List<UserLogin> GetUserLogins()
    {
        return this._users.Set<UserLogin>().ToList();
    }

    public UserModel? getByEmail(string email)
    {
        var query = from u in _users.users
                    where u.EmailAddress.ToLower().Equals(email.ToLower())
                    select u;

        return query.FirstOrDefault();
    }
}