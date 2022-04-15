using NotesARK6.Messages;
using NotesARK6.Model;
using NotesARK6.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace NotesARK6.ViewModel
{
    public class WindowCreateAndEditNoteViewModel : INotifyPropertyChanged
    {
        private NotesCollectionModel notesCollectionModel;
        private Note currentNote;
        private string windowTitle;
        private string content;

        private IMessenger messenger;
        private IControllDataBase controllDataBase;

        // Commands
        public ControllComands SaveNoteCommand { get; private set; }
        // Commands 

        public WindowCreateAndEditNoteViewModel(IMessenger messenger, IControllDataBase controllDataBase)
        {
            
            notesCollectionModel = NotesCollectionModel.notesCollection;

            this.messenger = messenger;
            this.controllDataBase = controllDataBase;

            messenger.Subscribe<CreateEditParametersMessage>(this, TakeMessage);

            SaveNoteCommand = new ControllComands(SaveNote);
        }

        public string WindowTitle
        {
            get
            {
                return windowTitle;
            }
            set
            {
                windowTitle = value;
                OnPropertyChanged("WindowTitle");
            }
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
            controllDataBase.Edit(currentNote, Content);
        }

        public void TakeMessage(object obj)
        {
            var message = (CreateEditParametersMessage)obj;
            windowTitle = message.NoteTitle;
            Content = message.Note.Content;
            currentNote = message.Note;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
