using NotesAndDutiesAPI.Models;

public interface ILoginRepository{
        public List<UserLogin> GetUserLogins();

        public UserModel? GetUser(UserLogin userData);
}