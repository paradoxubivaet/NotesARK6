using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesARK6.Messages
{
    public class GetIdMessage
    {
        public int Id { get; }
        public GetIdMessage(int id)
        {
            Id = id; 
        }
    }
}
