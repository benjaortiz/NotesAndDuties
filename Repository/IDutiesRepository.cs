using NotesAndDutiesAPI.Models;

public interface IDutiesRepository {
    public List<DutyModel> GetDuties();

    public DutyModel? GetDutyById(int id);

    //add
    void addDuty(DutyModel newDuty);
    //put
    DutyModel? replaceDuty(DutyModel updatedDuty);
    //patch

    //delete
    DutyModel? deleteDuty(DutyModel duty);

    DutyModel? deleteDuty(int id);
}