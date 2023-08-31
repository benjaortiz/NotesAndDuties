using NotesAndDutiesAPI.Models;

public interface IDutiesService
{
    //Post (add)
    DutyModel AddDuty(PostDutyModel newDuty, string dutyAuthor);

    //get (all) (could be used for admins)
    List<DutyModel> GetDuties();

    //get all from a specific user
    List<DutyModel> GetDuties(string user);

    //get 1 specific (could be used for admins)
    DutyModel? GetDuty(int id);

    DutyModel? GetDuty(int id, string user);

    //Delete
    DutyModel? DeleteDuty(int id);

    DutyModel? DeleteDuty(int id, string user);

    //Put
    DutyModel? ReplaceDuty(int id, DutyModelDTO updatedDuty);
}