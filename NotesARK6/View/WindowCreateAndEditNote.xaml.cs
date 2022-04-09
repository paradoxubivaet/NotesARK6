using NotesARK6.Model;
using NotesARK6.ViewModel;
using System;
using System.Windows;

namespace NotesARK6.View
{
    /// <summary>
    /// Логика взаимодействия для WindowCreateAndEditNote.xaml
    /// </summary>
    public partial class WindowCreateAndEditNote : Window
    {
        public WindowCreateAndEditNote(string noteTitle,ref Note note)
        {
            Resources.Add("Title", noteTitle);
            InitializeComponent();
            DataContext = new WindowCreateAndEditNoteViewModel(note);
        }
    }
}
