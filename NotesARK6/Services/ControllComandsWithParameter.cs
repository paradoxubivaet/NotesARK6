using NotesARK6.Model;
using System;
using System.Windows.Input;

namespace NotesARK6.ViewModel
{
    public class ControllComandsWithParameter : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<Note> _execute;
        
        public ControllComandsWithParameter(Action<Note> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke((Note)parameter);
        }
    }
}
