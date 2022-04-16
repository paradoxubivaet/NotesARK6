using Microsoft.Toolkit.Mvvm.DependencyInjection;
using NotesARK6.Messages;
using System.Collections.Generic;
using System.Windows;

namespace NotesARK6.Services
{
    public static class DictionaryWindows
    {
        public static Dictionary<int, Window> WindowsList { get; }
        public static int Counter { get; private set; }

        static DictionaryWindows()
        {
            WindowsList = new Dictionary<int, Window>();
            Counter = 0;
        }

        public static void Add(Window window,int counter)
        {
            Counter += 1;

            var messenger = Ioc.Default.GetService<IMessenger>();
            messenger.Send(new GetIdMessage(Counter));

            WindowsList.Add(Counter, window);
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
