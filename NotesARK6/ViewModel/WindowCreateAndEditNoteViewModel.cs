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
        private int windowId;

        private IMessenger messenger;
        private IControllDataBase controllDataBase;
        private IWindowService windowService;

        // Commands
        public ControllComands SaveNoteCommand { get; private set; }
        public ControllComands CloseWindowCommand { get; private set; }
        public ControllComands MaximizeWindowCommand { get; private set; }
        public ControllComands MinimizeWindowCommand { get; private set; }
        // Commands 

        public WindowCreateAndEditNoteViewModel(IMessenger messenger, 
                                                IControllDataBase controllDataBase,
                                                IWindowService windowService)
        {
            notesCollectionModel = NotesCollectionModel.notesCollection;

            this.messenger = messenger;
            this.controllDataBase = controllDataBase;
            this.windowService = windowService;

            messenger.Subscribe<CreateEditParametersMessage>(this, GetContent);
            messenger.Subscribe<GetIdMessage>(this, GetId);

            SaveNoteCommand = new ControllComands(SaveNote);
            CloseWindowCommand = new ControllComands(CloseWindow);
            MaximizeWindowCommand = new ControllComands(MaximizeWindow);
            MinimizeWindowCommand = new ControllComands(MinimizeWindow);

            windowId = -1;
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

        public void GetContent(object obj)
        {
            var message = (CreateEditParametersMessage)obj;
            windowTitle = message.NoteTitle;
            Content = message.Note.Content;
            currentNote = message.Note;
        }

        public void CloseWindow()
        {
            windowService.CloseWindow(windowId);
        }

        public void MaximizeWindow()
        {
            windowService.MaximizeWindow(windowId);
        }

        public void MinimizeWindow()
        {
            windowService.MinimizeWindow(windowId);
        }

        public void GetId(object obj)
        {
            var message = (GetIdMessage)obj;
            if (windowId == -1)
                windowId = message.Id;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
