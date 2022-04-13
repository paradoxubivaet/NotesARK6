using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace NotesARK6.ViewModel
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return Ioc.Default.GetService<MainWindowViewModel>();
            }
        }

        public FindNoteWindowViewModel FindNoteWindowViewModel
        {
            get 
            {
                return Ioc.Default.GetService<FindNoteWindowViewModel>(); 
            }
        }

        public WindowCreateAndEditNoteViewModel WindowCreateAndEditNoteViewModel
        {
            get 
            {
                return Ioc.Default.GetService<WindowCreateAndEditNoteViewModel>(); 
            }
        }
    }
}
