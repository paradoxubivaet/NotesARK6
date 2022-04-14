using Microsoft.Toolkit.Mvvm.DependencyInjection;
using NotesARK6.Messages;
using NotesARK6.Services;
using System.Windows;

namespace NotesARK6.View
{
    /// <summary>
    /// Логика взаимодействия для FindNoteWindow.xaml
    /// </summary>
    public partial class FindNoteWindow : Window
    {
        public FindNoteWindow()
        {
            InitializeComponent();
        }

        // Реализовать обработку закрытия окна в FindNoteWindowViewModel.cs (пока не знаю как)
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IMessenger messenger = Ioc.Default.GetService<IMessenger>();
            messenger.Send(new NotificationMessage(true));
        }
    }
}
