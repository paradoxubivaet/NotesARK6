using System;
using System.Collections.Generic;
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

namespace NotesARK6.ViewModel.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для FindWindowDialog.xaml
    /// </summary>
    public partial class FindWindowDialog : Window
    {
        public FindWindowDialog()
        {
            InitializeComponent();
            DataContext = new FindWindowDialogViewModel();
        }
    }
}
