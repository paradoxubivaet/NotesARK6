using System;

namespace NotesARK6.Services
{
    public interface IWindowService
    {
        void ShowWindow(string name);
        void CloseWindow(int id);
        void MaximizeWindow(int id);
        void MinimizeWindow(int id);
    }
}
