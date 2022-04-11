using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesARK6.Messages
{
    public class SearchSettingMessage
    {
        public string SearchText { get; }
        public bool SearchByName { get; }
        public bool SearchByContent { get; }

        public SearchSettingMessage(string searchText, bool searchByName, bool searchByContent)
        {
            SearchText = searchText;   
            SearchByName = searchByName;
            SearchByContent = searchByContent;
        }
    }
}
