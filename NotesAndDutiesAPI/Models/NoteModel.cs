using System.ComponentModel.DataAnnotations;

namespace NotesAndDutiesAPI.Models;

public class NoteModel {
    [Key]
    public int NoteId;

    public string Text;

    [Required]
    public string Author;
}

public class NoteModelDTO{
    public string Text;

    public string Author;
}