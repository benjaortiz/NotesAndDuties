using NotesAndDutiesAPI;
using NotesAndDutiesAPI.Models;

namespace Repository.NotesRepository;

public class NotesRepository : INotesRepository{

    private AppDbContext _notes;

    public NotesRepository(AppDbContext db){
        _notes = db;
    }

    public NoteModel addNote(NoteModel newNote)
    {
        throw new NotImplementedException();
    }

    public NoteModel? deleteNote(NoteModel note)
    {
        throw new NotImplementedException();
    }

    public NoteModel? GetNoteByIdAndUsername(int id, string username)
    {
        throw new NotImplementedException();
    }

    public List<NoteModel> GetNotesByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public NoteModel replaceNote(NoteModel updatedNote)
    {
        throw new NotImplementedException();
    }
}