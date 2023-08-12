using NotesAndDutiesAPI.Models;

public interface IDutiesRepository {
    List<DutyModel> GetDuties();

    DutyModel? GetDutyById(int id);

    //add
    DutyModel addDuty(DutyModel newDuty);
    //put
    DutyModel? replaceDuty(DutyModel updatedDuty);
    //patch

    //delete
    DutyModel? deleteDuty(DutyModel duty);

    DutyModel? deleteDuty(int id);
}