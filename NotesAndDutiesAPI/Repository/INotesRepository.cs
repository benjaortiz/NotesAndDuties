using NotesAndDutiesAPI.Models;

public interface INotesRepository {

    List<NoteModel> GetNotesByUsername(string username);

    NoteModel? GetNoteByIdAndUsername(int id, string username);

    //add
    NoteModel addNote(NoteModel newNote);

    //put
    NoteModel replaceNote(NoteModel updatedNote);

    //delete
    NoteModel? deleteNote(NoteModel note);
}