using NotesAndDutiesAPI.Models;

namespace Repository.IDutiesRepository;

public interface IDutiesRepository {
    public List<DutyModel> GetDuties();
}