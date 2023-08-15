using System.ComponentModel.DataAnnotations;

namespace NotesAndDutiesAPI.Models;

public enum DutyStatus{
    ToDo,
    InProgress,
    Done
}
public class DutyModel {
    [Key]
    public int DutyId {get; set;}
    public string Title {get; set;}

    public DutyStatus Status {get; set;}

    public string? Description {get; set;}
}

public class PostDutyModel {
    public string Title {get; set;}

    public DutyStatus Status {get; set;}

    public string? Description {get; set;}
}