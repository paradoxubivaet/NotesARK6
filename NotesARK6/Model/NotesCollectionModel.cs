using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesARK6.Model
{
    public class NotesCollectionModel
    {
        public static NotesCollectionModel notesCollection = new NotesCollectionModel();
        public ObservableCollection<Note> NotesCollection { get; set; }
    }
}
