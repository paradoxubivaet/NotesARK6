using Microsoft.Toolkit.Mvvm.DependencyInjection;
using NotesARK6.Messages;
using System.Collections.Generic;
using System.Windows;

namespace NotesARK6.Services
{
    public static class DictionaryWindows
    {
        public static Dictionary<int, Window> WindowsList { get; }

        static DictionaryWindows()
        {
            WindowsList = new Dictionary<int, Window>();
        }

        public static void Add(Window window,int counter)
        {
            var messenger = Ioc.Default.GetService<IMessenger>();
            WindowsList.Add(counter, window);

            messenger.Send(new GetIdMessage(counter));
        }

        public static void Remove(int windowId)
        {
            if (WindowsList.ContainsKey(windowId)) 
            {
                WindowsList[windowId].Close();
                WindowsList.Remove(windowId); 
            }

        }

        public static Window GetWindow(int windowId)
        {
            return WindowsList[windowId];
        }
    }
}
