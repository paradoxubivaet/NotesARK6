using System;
using System.Windows.Input;

namespace NotesARK6.ViewModel
{
    public class ControllComands : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action _execute;
        public ControllComands(Action execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
