using NotesAndDutiesAPI;
using NotesAndDutiesAPI.Models;

namespace Repository.DutiesRepository;

public class DutiesRepository : IDutiesRepository
{
    private AppDbContext _duties;

    public DutiesRepository(AppDbContext db)
    {
        _duties = db;
    }

    public void addDuty(DutyModel newDuty)
    {
        this._duties.Add(newDuty);
        this._duties.SaveChanges();
    }

    public DutyModel? deleteDuty(DutyModel duty)
    {
        DutyModel chosenDuty = this.GetDutyById(duty.DutyId);
        
        if (chosenDuty != null){
            this._duties.Remove(chosenDuty);
        }
        this._duties.SaveChanges();

        return chosenDuty;
    }

    public DutyModel? deleteDuty(int id)
    {
        DutyModel chosenDuty = this.GetDutyById(id);
        
        if (chosenDuty != null){
            this._duties.Remove(chosenDuty);
        }
        this._duties.SaveChanges();

        return chosenDuty;
    }

    public List<DutyModel> GetDuties()
    {
        return this._duties.Set<DutyModel>().ToList();
    }

    public DutyModel? GetDutyById(int id)
    {
        return this._duties.duties.Find(id);
    }

    public DutyModel? replaceDuty(DutyModel updatedDuty)
    {
        DutyModel? oldDuty = this.GetDutyById(updatedDuty.DutyId);

        if (oldDuty != null){
            this._duties.Remove(oldDuty);
            this._duties.Add(updatedDuty);
            this._duties.SaveChanges();
        }

        return oldDuty;
    }
}