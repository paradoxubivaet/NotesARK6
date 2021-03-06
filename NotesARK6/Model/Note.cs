using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotesARK6.Model
{
    public class Note : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string content;

        public Note()
        {
        }

        public Note(string name)
        {
            Name = name;
        }

        public Note(string name, string content)
        {
            Name = name;
            Content = content;
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Content
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop= "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
