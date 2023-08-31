using NotesAndDutiesAPI.Models;

public interface ILoginService
{

    public UserModel AuthenticateUser(UserLogin loginData);

    public string GenerateJwt(UserModel user);

    public UserModel? addNewUser(UserModelDto newUser);
}