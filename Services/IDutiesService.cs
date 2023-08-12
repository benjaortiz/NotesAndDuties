using Models.PostDutyModel;
using NotesAndDutiesAPI.Models;

public interface IDutiesService {
    //Post (add)
    DutyModel AddDuty(PostDutyModel newDuty);

    //get (all)
    List<DutyModel> GetDuties();

    //get 1 specific
    DutyModel? GetDuty(int id);

    //update (put)
    DutyModel? ReplaceDuty(DutyModel updatedDuty);
    //patch

    //Delete
    DutyModel? DeleteDuty(int id);
    DutyModel? ReplaceDuty(int id, PostDutyModel updatedDuty);
}