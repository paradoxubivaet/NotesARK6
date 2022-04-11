using NotesARK6.ViewModel.Dialogs;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesARK6.ViewModel
{
    public class DialogService : IDialogService
    {
        public void ShowDialog()
        {
            var dialog = new FindWindowDialog();

            dialog.Show();
        }
    }
}
