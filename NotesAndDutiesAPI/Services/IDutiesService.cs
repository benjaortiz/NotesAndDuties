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

    //update (put)
    DutyModel? ReplaceDuty(DutyModel updatedDuty);
    //patch

    //Delete
    DutyModel? DeleteDuty(int id);
    DutyModel? ReplaceDuty(int id, PostDutyModel updatedDuty);
}