using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesAndDutiesAPI.Models;

public enum DutyStatus
{
    ToDo,
    InProgress,
    Done
}

// Class that represents a specific Duty
public class DutyModel
{
    [Key]
    public int DutyId { get; set; }
    public string Title { get; set; }

    public DutyStatus Status { get; set; }

    public string? Description { get; set; }

    [Required]
    public string Author { get; set; }
}

// A DutyModel DTO, meant to be used to store new Duties information 
// Does not have a DutyId since clients are not meant to choose one and
// it is auto-generated.
public class PostDutyModel
{
    public string Title { get; set; }

    public DutyStatus Status { get; set; }

    public string? Description { get; set; }
}

public class DutyModelDTO
{
    public DutyModelDTO(PostDutyModel duty, string username)
    {
        Title = duty.Title;
        Status = duty.Status;
        Description = duty.Description;
        Author = username;
    }

    public string Title { get; set; }

    public DutyStatus Status { get; set; }

    public string? Description { get; set; }

    public string Author { get; set; }
}