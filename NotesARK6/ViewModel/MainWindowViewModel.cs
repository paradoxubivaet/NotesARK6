using System;
using NotesARK6.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using NotesARK6.Services;
using NotesARK6.Messages;


namespace NotesARK6.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private NotesCollectionModel notesCollectionModel;
        private Note selectedNote;

        private IWindowService windowService;
        public IMessenger messenger;
        

        // Controll comands {
        public ControllComands CreateNewNoteCommand { get; private set; }
        public ControllComands FindNoteCommand { get; private set; }
        public ControllComandsWithParameter DeleteNoteCommand { get; private set; }
        public ControllComandsWithParameter EditNoteCommand { get; private set; }
        // Controll comands }

        public MainWindowViewModel(IMessenger messenger, IWindowService windowService)
        {
            CreateNewNoteCommand = new ControllComands(CreateNewNote);
            DeleteNoteCommand = new ControllComandsWithParameter(DeleteNote);
            EditNoteCommand = new ControllComandsWithParameter(EditNote);
            FindNoteCommand = new ControllComands(FindNote);

            notesCollectionModel = NotesCollectionModel.notesCollection;
            notesCollectionModel.NotesCollection =
                    new ObservableCollection<Note> { new Note("today", "i'm a testing note :o"),
                    new Note("today", "yeah bro")};


            this.messenger = messenger;
            this.windowService = windowService;
            messenger.Subscribe<SearchSettingMessage>(this, MethodForMessage);
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
            Note note = new Note(noteTitle);
            NotesCollection.Add(note);

            windowService.ShowWindow("WindowCreateAndEditNote");
            messenger.Send(new CreateEditParametersMessage(noteTitle, ref note));
        }

        // Delete note
        public void DeleteNote(Note note)
        {
            NotesCollection.Remove(note);
        }

        public void FindNote()
        {
            windowService.ShowWindow("FindNoteWindow");
        }

        public void MethodForMessage(object obj)
        {
            var message = (SearchSettingMessage)obj;
            SortNotes(message.SearchText);
        }

        public void SortNotes(string searchString)
        {
            ICollectionView notesView = CollectionViewSource.GetDefaultView(this.NotesCollection);
            notesView.Filter = item => (item as Note).Content.Contains(searchString);
        }

        public void EditNote(Note note)
        {
            string noteTitle = note.Name;

            windowService.ShowWindow("WindowCreateAndEditNote");
            messenger.Send(new CreateEditParametersMessage(noteTitle, ref note));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
