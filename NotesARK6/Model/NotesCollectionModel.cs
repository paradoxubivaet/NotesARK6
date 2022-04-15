using System.Collections.ObjectModel;

namespace NotesARK6.Model
{
    public class NotesCollectionModel
    {
        public static NotesCollectionModel notesCollection = new NotesCollectionModel();
        public ObservableCollection<Note> NotesCollection { get; set; }
    }
}
