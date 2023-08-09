using NotesAndDutiesAPI;
using NotesAndDutiesAPI.Models;

namespace Repository.UserRepository;

public class UserRepository : IUserRepository
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

    public UserModel getById(int id)
    {

        var query = from u in _users.users
                    where u.UserId == id
                    select u;

        return query.First();
    }

    public UserModel getByName(string username)
    {
        /*
        var query = from u in _users.users
                    where u.Username.Equals(username)
                    select u;
        */
        return this._users.users.Where(d => d.Username == username).FirstOrDefault<UserModel>();
    }

    void IUserRepository.addUser(UserModel newUser)
    {
        this._users.users.Add(newUser);
    }
}