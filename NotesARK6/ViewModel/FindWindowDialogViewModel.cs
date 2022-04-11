using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotesARK6.ViewModel.Dialogs
{
    public class FindWindowDialogViewModel : INotifyPropertyChanged
    {
        private string searchString;
        private bool searchByName;
        private bool searchByContent;

        //Controll commands
        public ControllComands FindNotesCommand { get; private set; }
        //Controll commands

        public FindWindowDialogViewModel()
        {
            FindNotesCommand = new ControllComands(FindNote);
        }

        public string SearchString 
        {
            get
            {
                return searchString;
            }
            set
            {
                searchString = value;
                OnPropertyChanged();
            }
        }

        public bool SearchByName
        {
            get
            {
                return searchByName;
            }
            set
            {
                searchByName = value;
                OnPropertyChanged("SearchByName");
            }
        }

        public bool SearchByContent
        {
            get
            {
                return searchByContent;
            }
            set
            {
                searchByContent = value;
                OnPropertyChanged("SearchByContent");
            }
        }

        public void FindNote()
        {
           
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
