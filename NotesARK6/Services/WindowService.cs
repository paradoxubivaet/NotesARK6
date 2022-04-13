using System;
using System.Windows;
using System.Windows.Controls;

namespace NotesARK6.Services
{
    public class WindowService : IWindowService
    {
        public void ShowWindow(string name)
        {
            var type = Type.GetType($"NotesARK6.View.{name}");
            var window = (Window)Activator.CreateInstance(type);

            window.Show();
        }

        //public void ShowWindowSecond()
        //{
            //var window = new Window();

            //var type = Type.GetType($"NotesARK6.View.{name}");
            //window.Content = Activator.CreateInstance(type);

            //window.Show();
        //}
    }
}
