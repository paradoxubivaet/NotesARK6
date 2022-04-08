using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NotesARK6.View;
using NotesARK6.Model;
using System.Collections.ObjectModel;
using Prism.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotesARK6.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Note> notesCollection =
            new ObservableCollection<Note> { new Note("today", "i'm a testing note :o") };
        private Note selectedNote;


        // Команды управления {
        public ControllComands CreateNewNoteCommand { get; private set; }
        public ControllComandsWithParameter DeleteNoteCommand { get; private set; }
        public ControllComands FindNoteCommand { get; private set; }
        // Команды управления }

        public MainWindowViewModel()
        {
            CreateNewNoteCommand = new ControllComands(CreateNewNote);
            DeleteNoteCommand = new ControllComandsWithParameter(DeleteNote);
            FindNoteCommand = new ControllComands(FindNote);
        }

        public ObservableCollection<Note> NotesCollection
        { 
            get 
            {
                return notesCollection;
            }
            set
            {
                notesCollection = value;
            }
        }

        public Note SelectedNote
        {
            get
            {
                return selectedNote;
            }
            set
            {
                selectedNote = value;
                OnPropertyChanged("SelectedNote");
            }
        }

        public void CreateNewNote()
        {
            string noteTitle = DateTime.Now.ToString();
            WindowCreateAndEditNote newNoteWindow = new WindowCreateAndEditNote(noteTitle);
            newNoteWindow.Show();
        }

        //Удаление заметки
        public void DeleteNote(Note note)
        {
            NotesCollection.Remove(note);

            MessageBox.Show(NotesCollection.Count.ToString());
        }

        public void FindNote()
        {

        }

        // PropertyChanged 
        // Пока не совсем понимаю, для чего это нужно

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
