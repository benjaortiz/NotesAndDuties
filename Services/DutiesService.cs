using NotesAndDutiesAPI;
using NotesAndDutiesAPI.Models;

namespace Services.DutiesService;

public class DutiesService : IDutiesService {
    
    private IDutiesRepository _duties;

    public DutiesService(IDutiesRepository duties){
        _duties = duties;
    }

    public DutyModel AddDuty(DutyModel newDuty)
    {
        //should validate that the Id is correct before searching (not 0 or negative)
        DutyModel oldDuty = this._duties.GetDutyById(newDuty.DutyId);
        
        if (oldDuty == null){
            this._duties.addDuty(newDuty);
        }

        return oldDuty;
    }

    public void DeleteDuty(DutyModel duty)
    {
        if(this._duties.GetDutyById(duty.DutyId) != null){
            this._duties.deleteDuty(duty);
        }
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