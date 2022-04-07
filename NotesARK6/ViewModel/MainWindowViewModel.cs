using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NotesARK6.View;
using NotesARK6.Model;

namespace NotesARK6.ViewModel
{
    public class MainWindowViewModel
    {
        public ControllComands CreateNewNoteCommand { get; private set; }

        public MainWindowViewModel()
        {
            CreateNewNoteCommand = new ControllComands(CreateNewNote);
        }

        public void CreateNewNote()
        {
            string noteTitle = DateTime.Now.ToString();
            WindowCreateAndEditNote newNoteWindow = new WindowCreateAndEditNote(noteTitle);

            Note note = new Note(noteTitle);
            newNoteWindow.Show();
        }

        public void DeleteNote()
        {

        }

        public void FindNote()
        {

        }
    }
}
