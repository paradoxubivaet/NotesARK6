using NotesARK6.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesARK6.Messages
{
    public class CreateEditParametersMessage
    {
        public string NoteTitle { get; }
        public Note Note { get; }

        public CreateEditParametersMessage(string noteTitle, ref Note note)
        {
            NoteTitle = noteTitle;
            Note = note;
        }
    }
}
