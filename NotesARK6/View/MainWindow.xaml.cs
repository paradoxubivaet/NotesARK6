using System.Windows;

namespace NotesARK6.View
{
    public partial class MainWindow : Window
    {
        private NoteContext context { get; }

        public MainWindow()
        {
            InitializeComponent();

            //context = new NoteContext();
            //DataContext = new MainWindowViewModel();
        }
    }
}
