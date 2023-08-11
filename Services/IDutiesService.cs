using NotesAndDutiesAPI.Models;

public interface IDutiesService {
    //Post (add)
    DutyModel AddDuty(DutyModel newDuty);

    //get (all)
    List<DutyModel> GetDuties();

    //get 1 specific
    DutyModel? GetDuty(int id);

    //update (put)
    DutyModel? ReplaceDuty(DutyModel updatedDuty);
    //patch

    //Delete
    void DeleteDuty(DutyModel duty);
}