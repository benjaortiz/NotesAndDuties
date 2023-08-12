using Models.PostDutyModel;
using NotesAndDutiesAPI;
using NotesAndDutiesAPI.Models;

namespace Services.DutiesService;

public class DutiesService : IDutiesService {
    
    private IDutiesRepository _duties;

    public DutiesService(IDutiesRepository duties){
        _duties = duties;
    }

    public DutyModel AddDuty(PostDutyModel newDuty)
    {
        DutyModel duty = new DutyModel{Title = newDuty.Title,
                                    Status = newDuty.Status, 
                                    Description = newDuty.Description};
        //should validate that the Id is correct before searching (not 0 or negative)
        DutyModel addedDuty = this._duties.addDuty(duty);

        return addedDuty;
    }

    public DutyModel? DeleteDuty(int id)
    {
        DutyModel? dutyToDelete = this._duties.GetDutyById(id);
        if(dutyToDelete != null){
            this._duties.deleteDuty(id);
        }

        return dutyToDelete;
    }

    public List<DutyModel> GetDuties()
    {
        return this._duties.GetDuties();
    }

    public DutyModel? GetDuty(int id)
    {
        return this._duties.GetDutyById(id);
    }

    public DutyModel? ReplaceDuty(DutyModel updatedDuty)
    {
        return this._duties.replaceDuty(updatedDuty);
    }
}