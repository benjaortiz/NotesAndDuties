using NotesAndDutiesAPI.Models;

public interface IDutiesRepository {
    List<DutyModel> GetDuties();

    DutyModel? GetDutyById(int id);

    List<DutyModel> GetDutiesByUsername(string username);

    //add
    DutyModel addDuty(DutyModel newDuty);
    //put
    DutyModel? replaceDuty(DutyModel updatedDuty);
    //patch

    //delete
    DutyModel? deleteDuty(DutyModel duty);

    DutyModel? deleteDuty(int id);
}