using NotesAndDutiesAPI.Models;


public interface IUserRepository {
    public List<UserModel> GetUserModels();

    public UserModel? getById(int id);

    public UserModel? getByName(string username);

    public UserModel addUser(UserModel newUser);
    
    public UserModel? getByEmail(string email);
    
    //put

    //patch
}