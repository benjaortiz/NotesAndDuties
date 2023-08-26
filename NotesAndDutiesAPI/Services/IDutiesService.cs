using NotesAndDutiesAPI.Models;

public interface IDutiesService {
    //Post (add)
    DutyModel AddDuty(PostDutyModel newDuty, string dutyAuthor);

    //get (all)
    List<DutyModel> GetDuties();

    //get all from a specific user
    List<DutyModel> GetDuties(string user);

    //get 1 specific
    DutyModel? GetDuty(int id);

    DutyModel? GetDuty(int id, string user);

    //update (put)
    DutyModel? ReplaceDuty(DutyModel updatedDuty);
    //patch

    //Delete
    DutyModel? DeleteDuty(int id);
    DutyModel? ReplaceDuty(int id, PostDutyModel updatedDuty);

    DutyModel? DeleteDuty(int id, string user);
    DutyModel? ReplaceDuty(int id, PostDutyModel updatedDuty, string user);
}