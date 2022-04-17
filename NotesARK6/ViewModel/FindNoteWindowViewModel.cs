using NotesARK6.Messages;
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
        private IWindowService windowService; 
        private int windowId;

        //Controll commands
        public ControllComands FindNotesCommand { get; private set; }
        public ControllComands WindowClosingCommand { get; private set; }
        public ControllComands CloseWindowCommand { get; private set; }
        public ControllComands MaximizeWindowCommand { get; private set; }
        public ControllComands MinimizeWindowCommand { get; private set; }
        //Controll commands

        public FindNoteWindowViewModel(IMessenger messenger, IWindowService windowService)
        {
            FindNotesCommand = new ControllComands(FindNote);
            WindowClosingCommand = new ControllComands(WindowClosing);
            CloseWindowCommand = new ControllComands(CloseWindow);
            MaximizeWindowCommand = new ControllComands(MaximizeWindow);
            MinimizeWindowCommand = new ControllComands(MinimizeWindow);

            this.messenger = messenger;
            this.windowService = windowService;

            messenger.Subscribe<GetIdMessage>(this, GetId);

            windowId = -1;
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
