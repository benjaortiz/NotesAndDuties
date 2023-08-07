using NotesAndDutiesAPI.Models;


public interface IUserRepository {
    public List<UserModel> GetUserModels();

    public UserModel getById(int id);

    public UserModel getByName(string username);
}