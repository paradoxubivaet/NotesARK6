using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesARK6.Messages
{
    public class NotificationMessage
    {
        public bool IsClose { get; }
        public NotificationMessage(bool isClose)
        {
            IsClose = isClose;
        }
    }
}
