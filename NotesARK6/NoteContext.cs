using NotesARK6.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesARK6
{
    public class NoteContext : DbContext
    {
        public NoteContext() : base("NotesDBconnectionString")
        {
            Database.CreateIfNotExists();
        } 

        public DbSet<Note> Notes { get; set; }
    }
}
