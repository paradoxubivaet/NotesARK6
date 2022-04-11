using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NotesARK6.View;
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
        private IDialogService dialogService;
        private IMessenger messenger;

        // Controll comands {
        public ControllComands CreateNewNoteCommand { get; private set; }
        public ControllComands FindNoteCommand { get; private set; }

        // added right now 
        public ControllComands SortNotesCommand { get; private set; }
        private string searchString = "testing";
        // added right now 

        public ControllComandsWithParameter DeleteNoteCommand { get; private set; }
        public ControllComandsWithParameter EditNoteCommand { get; private set; }
        // Controll comands }

        public MainWindowViewModel()
        {
            CreateNewNoteCommand = new ControllComands(CreateNewNote);
            DeleteNoteCommand = new ControllComandsWithParameter(DeleteNote);
            EditNoteCommand = new ControllComandsWithParameter(EditNote);
            FindNoteCommand = new ControllComands(FindNote);
            messenger = new Messenger();
            messenger.Subscribe<SearchSettingMessage>(this, SortNotes);
            // added right now
            SortNotesCommand = new ControllComands(SortNotes);
            // adder right now 

            dialogService = new DialogService();

            notesCollectionModel = NotesCollectionModel.notesCollection;
            notesCollectionModel.NotesCollection = 
                    new ObservableCollection<Note> { new Note("today", "i'm a testing note :o"),
                    new Note("today", "yeah bro")};

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

            WindowCreateAndEditNote noteWindow = new WindowCreateAndEditNote(noteTitle,ref note);
            noteWindow.Show();
        }

        // Delete note
        public void DeleteNote(Note note)
        {
            NotesCollection.Remove(note);
        }

        public void FindNote()
        {
            dialogService.ShowDialog();
        }

        public void SortNotes(object obj)
        {
            var message = (SearchSettingMessage)obj;
            //ICollectionView notesView = CollectionViewSource.GetDefaultView(this.NotesCollection);
            //notesView.Filter = item => (item as Note).Content.Contains(searchString);
        }

        public void EditNote(Note note)
        {
            string noteTitle = note.Name;
            WindowCreateAndEditNote noteWindow = new WindowCreateAndEditNote(noteTitle,ref note);

            noteWindow.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
