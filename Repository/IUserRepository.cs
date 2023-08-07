using NotesAndDutiesAPI.Models;

namespace Repository.IUserRepository;

public interface IUserRepository {
    public List<UserModel> GetUserModels();
}