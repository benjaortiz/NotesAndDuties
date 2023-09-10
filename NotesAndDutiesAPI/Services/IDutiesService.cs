using NotesAndDutiesAPI.Models;

public interface IDutiesService
{
    //Post (add)
    DutyModel AddDuty(PostDutyModel newDuty, string dutyAuthor);

    //get all from a specific user
    List<DutyModel> GetDuties(string user);

    DutyModel GetDuty(int id, string user);

    DutyModel DeleteDuty(int id, string user);

    //Put
    DutyModel ReplaceDuty(int id, DutyModelDTO updatedDuty);
}