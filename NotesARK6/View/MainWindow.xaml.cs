using NotesARK6.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotesARK6.View
{
    public partial class MainWindow : Window
    {
        private NoteContext context { get; }

        public MainWindow()
        {
            InitializeComponent();

            context = new NoteContext();
            //DataContext = new MainWindowViewModel();
        }
    }
}
