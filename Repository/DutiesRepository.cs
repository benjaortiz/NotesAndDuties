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

    public List<DutyModel> GetDuties()
    {
        return this._duties.Set<DutyModel>().ToList();
    }

    public DutyModel GetDutyById(int id)
    {
        return this._duties.duties.Find(id);
    }
}