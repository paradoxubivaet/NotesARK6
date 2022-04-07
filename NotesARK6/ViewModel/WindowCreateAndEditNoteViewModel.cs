using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesARK6.ViewModel
{
    public class WindowCreateAndEditNoteViewModel
    {
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
