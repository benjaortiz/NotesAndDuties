using System.ComponentModel.DataAnnotations;

namespace NotesAndDutiesAPI.Models;

public class NoteModel
{
    [Key]
    public int NoteId { get; set; }

    public string Text { get; set; }

    [Required]
    public string Author { get; set; }
}

public class NoteModelDTO
{
    public string Text;

    public string Author;
}