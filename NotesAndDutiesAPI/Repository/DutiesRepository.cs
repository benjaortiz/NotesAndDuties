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

    public DutyModel addDuty(DutyModel newDuty)
    {
        this._duties.Add(newDuty);
        this._duties.SaveChanges();

        return newDuty;
    }

    public DutyModel? deleteDuty(DutyModel duty)
    {
        DutyModel? dutyToDelete = this.GetDutyById(duty.DutyId);

        if (dutyToDelete != null)
        {
            this._duties.Remove(dutyToDelete);
        }
        this._duties.SaveChanges();

        return dutyToDelete;
    }

    public DutyModel? deleteDuty(int id)
    {
        DutyModel? chosenDuty = this.GetDutyById(id);

        if (chosenDuty != null)
        {
            this._duties.Remove(chosenDuty);
        }
        this._duties.SaveChanges();

        return chosenDuty;
    }

    public List<DutyModel> GetDuties()
    {
        return this._duties.Set<DutyModel>().ToList();
    }

    public List<DutyModel> GetDutiesByUsername(string username)
    {
        var query = from d in this._duties.duties
                    where d.Author.Equals(username.ToLower())
                    select d;

        return query.ToList();
    }

    public DutyModel? GetDutyById(int id)
    {
        return this._duties.duties.Find(id);
    }

    public DutyModel? GetDutyByIdAndUsername(int id, string username)
    {
        var query = from d in _duties.duties
                    where d.DutyId == id && d.Author.ToLower().Equals(username.ToLower())
                    select d;

        return query.FirstOrDefault();
    }

    public DutyModel? replaceDuty(DutyModel updatedDuty)
    {

        switch (this.GetDutyById(updatedDuty.DutyId))
        {
            case null:
                throw new NullReferenceException("Could not find the duty that wants to be updated");
            case DutyModel:
            default:
                break;
        };



        DutyModel? oldDuty = this.GetDutyById(updatedDuty.DutyId);

        if (oldDuty != null)
        {
            //small patch, validation on this field should be done in the DutiesService
            updatedDuty.Author = oldDuty.Author;
            this._duties.Remove(oldDuty);
            this._duties.Add(updatedDuty);
            this._duties.SaveChanges();
        }

        return oldDuty;
    }
}