namespace NotesAndDutiesAPI.Models;

public enum DutyStatus{
    ToDo,
    InProgress,
    Done
}
public class DutyModel {
    public string Title {get; set;}

    public DutyStatus Status {get; set;}

    public string? Description {get; set;}
}