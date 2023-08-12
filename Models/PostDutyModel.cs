using System.ComponentModel.DataAnnotations;
using NotesAndDutiesAPI.Models;

namespace Models.PostDutyModel;
public class PostDutyModel {
    public string Title {get; set;}

    public DutyStatus Status {get; set;}

    public string? Description {get; set;}
}