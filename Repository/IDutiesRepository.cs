using NotesAndDutiesAPI.Models;

public interface IDutiesRepository {
    public List<DutyModel> GetDuties();

    public DutyModel GetDutyById(int id);

    //add

    //put

    //patch

    //delete

}