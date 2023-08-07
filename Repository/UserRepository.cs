using NotesAndDutiesAPI;
using NotesAndDutiesAPI.Models;

namespace Repository.UserRepository;

public class UserRepository : IUserRepository {
    private AppDbContext _users;

    public UserRepository(AppDbContext db){
        _users = db;
    }

    public List<UserModel> GetUserModels(){
        return this._users.Set<UserModel>().ToList();
    }

    public UserModel getById(int id){
        return this._users.users.Find(id);
    }

    public UserModel getByName(string username){
        return this._users.users.Where(d => d.Username == username).FirstOrDefault<UserModel>();
    }
}