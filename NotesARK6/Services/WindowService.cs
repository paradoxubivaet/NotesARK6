using System;
using System.Windows;

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
    }
}
