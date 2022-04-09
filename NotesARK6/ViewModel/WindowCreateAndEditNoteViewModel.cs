using NotesARK6.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotesARK6.ViewModel
{
    public class WindowCreateAndEditNoteViewModel : INotifyPropertyChanged
    {
        private NotesCollectionModel notesCollectionModel;
        private string content { get; set; }
        private Note currentNote;

        // Команды
        public ControllComands SaveNoteCommand { get; private set; }
        // Команды 

        public WindowCreateAndEditNoteViewModel(Note note) 
        {
            currentNote = note;
            notesCollectionModel = NotesCollectionModel.notesCollection;

            SaveNoteCommand = new ControllComands(SaveNote);
        }

        public string Content 
        { 
            get 
            {
                return content;
            }  
            set
            {
                content = value;
                OnPropertyChanged("Content");
            } 
        }

        public ObservableCollection<Note> NotesCollection 
        {
            get
            {
                return notesCollectionModel.NotesCollection;
            }
            set
            {
                notesCollectionModel.NotesCollection = value;
            }
        }

        public void SaveNote()
        {
            currentNote.Content = Content;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
