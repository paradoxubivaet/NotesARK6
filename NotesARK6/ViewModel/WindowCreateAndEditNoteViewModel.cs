using NotesARK6.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesARK6.ViewModel
{
    public class WindowCreateAndEditNoteViewModel
    {
        private ObservableCollection<Note> NotesCollection;
        private string Content { get; set; }
        public ControllComands SaveNoteCommand { get; private set; }
        public WindowCreateAndEditNoteViewModel () 
        {
            SaveNoteCommand = new ControllComands(SaveNote);
        }
        
        public void SaveNote()
        {

        }
    }
}
