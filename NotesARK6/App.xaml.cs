using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using NotesARK6.Services;
using NotesARK6.View;
using NotesARK6.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
                .BuildServiceProvider()
                );
        }   
    }
}
