﻿using NotesARK6.Messages;
using NotesARK6.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotesARK6.ViewModel
{
    public class FindNoteWindowViewModel : INotifyPropertyChanged
    {
        private string searchString;
        private bool searchByName;
        private bool searchByContent;
        private IMessenger messenger; 

        //Controll commands
        public ControllComands FindNotesCommand { get; private set; }
        public ControllComands WindowClosingCommand { get; private set; }
        //Controll commands

        public FindNoteWindowViewModel(IMessenger messenger)
        {
            FindNotesCommand = new ControllComands(FindNote);
            WindowClosingCommand = new ControllComands(WindowClosing);
            this.messenger = messenger;
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
                OnPropertyChanged("SearchString");
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
            if (SearchString != null)
                messenger.Send(new SearchSettingMessage(SearchString, SearchByName, SearchByContent));
        }

        public void WindowClosing()
        {
            messenger.Send(new NotificationMessage(true));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
