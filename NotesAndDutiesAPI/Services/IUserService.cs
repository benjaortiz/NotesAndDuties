using NotesAndDutiesAPI.Models;

public interface IUserService
{
    //Post (add)
    public UserModel? addNewUser(UserModelDto newUser);
    //get (all)
    public UserModel? getUser(UserLogin user);

    UserModel? getUser(UserModel user);
}