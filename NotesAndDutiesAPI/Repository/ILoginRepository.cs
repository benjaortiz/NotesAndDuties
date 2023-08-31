using NotesAndDutiesAPI.Models;

public interface ILoginRepository
{
    public List<UserLogin> GetUserLogins();

    public List<UserModel> GetUserModels();

    public UserModel? GetUser(UserLogin userData);

    public UserModel? addUser(UserModel newUser);
}