using NotesAndDutiesAPI;
using NotesAndDutiesAPI.Models;

namespace Services.DutiesService;

public class DutiesService : IDutiesService
{

    private IDutiesRepository _duties;

    private readonly ILogger<DutiesService> _logger;

    public DutiesService(IDutiesRepository duties, ILogger<DutiesService> logger)
    {
        _duties = duties;
        _logger = logger;
    }


    public DutyModel AddDuty(PostDutyModel newDuty, string dutyAuthor)
    {
        DutyModel duty = new DutyModel
        {
            Title = newDuty.Title,
            Status = newDuty.Status,
            Description = newDuty.Description,
            Author = dutyAuthor.ToLower()
        };

        DutyModel addedDuty = this._duties.addDuty(duty);

        return addedDuty;
    }


    public DutyModel DeleteDuty(int id, string user)
    {
        DutyModel? duty = this._duties.GetDutyByIdAndUsername(id, user);

        if (duty != null)
        {
            try
            {
                this._duties.deleteDuty(duty);
            }
            catch (NullReferenceException)
            {
                _logger.LogWarning($"Delete attempt: error retreiving duty with id: {id}");
                throw;
            }
        }
        else
        {
            _logger.LogWarning($"Unable to find a duty that matches id: {id} & user: {user}");
            throw new NullReferenceException($"Could not find a duty that matches both the requested id: {id} and author: {user}");
        }
        return duty;
    }


    public List<DutyModel> GetDuties(string user)
    {
        return this._duties.GetDutiesByUsername(user.ToLower());
    }
    //erase this
    public DutyModel? GetDuty(int id)
    {
        return this._duties.GetDutyById(id);
    }

    public DutyModel GetDuty(int id, string user)
    {
        DutyModel? duty = this._duties.GetDutyByIdAndUsername(id, user);

        if (duty == null)
        {
            _logger.LogWarning($"Unable to find a duty that matches id: {id} & user{user}");
            throw new NullReferenceException($"Could not find a duty that matches the given id: {id} & author: {user}");
        }

        return duty;
    }


    public DutyModel ReplaceDuty(int id, DutyModelDTO updatedDuty)
    {
        //make the full dutymodel out of the DTO
        DutyModel duty = new DutyModel
        {
            DutyId = id,
            Title = updatedDuty.Title,
            Status = updatedDuty.Status,
            Description = updatedDuty.Description,
            Author = updatedDuty.Author
        };

        //search for the duty in the repository
        DutyModel? oldDuty = this._duties.GetDutyByIdAndUsername(id, duty.Author);

        if (oldDuty == null)
        {
            _logger.LogWarning($"Unable to find a duty that matches id: {id} & user{duty.Author}");
            throw new NullReferenceException($"Could not find a duty that matches the requested id: {id} & author: {duty.Author}");
        }
        try
        {
            return this._duties.replaceDuty(duty);
        }
        catch (NullReferenceException)
        {
            _logger.LogWarning($"Replace attempt: unable to find a duty that matches id: {id} & user{duty.Author}");
            throw;
        }
    }
}