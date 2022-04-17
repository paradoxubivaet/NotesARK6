using System;
using NotesARK6.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using NotesARK6.Services;
using NotesARK6.Messages;
using System.Windows;

namespace NotesARK6.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private NotesCollectionModel notesCollectionModel;
        private Note selectedNote;

        private ICollectionView collectionView;
        private IWindowService windowService;
        private IMessenger messenger;
        private IControllDataBase controllDataBase;

        // Controll comands {
        public ControllComands CreateNewNoteCommand { get; private set; }
        public ControllComands FindNoteCommand { get; private set; }
        public ControllComandsWithParameter DeleteNoteCommand { get; private set; }
        public ControllComandsWithParameter EditNoteCommand { get; private set; }
        public ControllComands CloseWindowCommand { get; private set; }
        public ControllComands MaximizeWindowCommand { get; private set; }
        public ControllComands MinimizeWindowCommand { get; private set; }
        // Controll comands }

        public MainWindowViewModel(IMessenger messenger, IWindowService windowService, IControllDataBase controllDataBase)
        {
            CreateNewNoteCommand = new ControllComands(CreateNewNote);
            DeleteNoteCommand = new ControllComandsWithParameter(DeleteNote);
            EditNoteCommand = new ControllComandsWithParameter(EditNote);
            FindNoteCommand = new ControllComands(FindNote);
            CloseWindowCommand = new ControllComands(CloseWindow);
            MaximizeWindowCommand = new ControllComands(MaximizeWindow);
            MinimizeWindowCommand = new ControllComands(MinimizeWindow);


            notesCollectionModel = NotesCollectionModel.notesCollection;
            collectionView = CollectionViewSource.GetDefaultView(this.NotesCollection);

            this.messenger = messenger;
            this.windowService = windowService;
            this.controllDataBase = controllDataBase;

            messenger.Subscribe<SearchSettingMessage>(this, TakingSearchMessage);
            messenger.Subscribe<NotificationMessage>(this, ClearFilter);
            messenger.Subscribe<UpdateMessage>(this, UpdateSupport);
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
                OnPropertyChanged("NotesCollection");
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
            collectionView.Filter = null;

            string noteTitle = DateTime.Now.ToString();
            Note note = new Note(noteTitle);
            controllDataBase.Add(note);

            windowService.ShowWindow("WindowCreateAndEditNote");
            messenger.Send(new CreateEditParametersMessage(noteTitle, ref note));
        }

        public void DeleteNote(Note note)
        {
            if(note != null)
                controllDataBase.Remove(note);
        }

        public void FindNote()
        {
            windowService.ShowWindow("FindNoteWindow");
        }

        public void TakingSearchMessage(object obj)
        {
            var message = (SearchSettingMessage)obj;
            SortNotes(message.SearchText, message.SearchByContent, message.SearchByName);
        }

        public void SortNotes(string searchString, bool searchByContent, bool SearchByName)
        {
            if (searchByContent && !SearchByName)
                collectionView.Filter = item => (item as Note).Content.Contains(searchString);
            else if (SearchByName && !searchByContent)
                collectionView.Filter = item => (item as Note).Name.Contains(searchString);
            else if (searchByContent && SearchByName)
                collectionView.Filter = item => (item as Note).Name.Contains(searchString) || (item as Note).Content.Contains(searchString);
        }

        public void EditNote(Note note)
        {
            string noteTitle = note.Name;

            windowService.ShowWindow("WindowCreateAndEditNote");
            messenger.Send(new CreateEditParametersMessage(noteTitle, ref note));
        }

        private void ClearFilter(object obj)
        {
            var message = (NotificationMessage)obj;
            if(message.Flag)
                collectionView.Filter = null;
        }

        public void UpdateSupport(object obj)
        {
            var message = (UpdateMessage)obj;
            if (message.Flag == true)
                NotesCollection = notesCollectionModel.NotesCollection;
        }

        public void CloseWindow()
        {
            Application.Current.Shutdown();
        }

        public void MaximizeWindow()
        {
            var currentState = Application.Current.MainWindow.WindowState;
            if(currentState == WindowState.Normal)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else if(currentState == WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            else if(currentState == WindowState.Minimized)
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        public void MinimizeWindow()
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
