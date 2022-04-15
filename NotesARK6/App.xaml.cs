using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using NotesARK6.Model;
using NotesARK6.Services;
using NotesARK6.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace NotesARK6
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(new ServiceCollection()
                .AddSingleton<MainWindowViewModel>()
                .AddTransient<FindNoteWindowViewModel>()
                .AddTransient<WindowCreateAndEditNoteViewModel>()
                .AddSingleton<IWindowService, WindowService>()
                .AddSingleton<IMessenger, Messenger>()
                .AddTransient<IControllDataBase, ControllDataBase>()
                .BuildServiceProvider()
                );

            Dumping();
        }

        public void Dumping()
        {
            using (NoteContext context = new NoteContext())
            {
                List<Note> notes = context.Notes.ToList();
                NotesCollectionModel.notesCollection.NotesCollection = new ObservableCollection<Note>(notes);
            }
        }
    }
}
