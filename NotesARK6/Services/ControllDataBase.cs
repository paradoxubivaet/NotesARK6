using Microsoft.Toolkit.Mvvm.DependencyInjection;
using NotesARK6.Messages;
using NotesARK6.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NotesARK6.Services
{
    public class ControllDataBase : IControllDataBase
    {
        private IMessenger messenger = Ioc.Default.GetService<IMessenger>();

        public void Add(Note note)
        {
            using(NoteContext context = new NoteContext())
            {
                context.Notes.Add(note);
                context.SaveChanges();
                Update();
            }
        }

        public void Remove(Note note)
        {
            using(NoteContext context = new NoteContext())
            {
                var noteDeleting = context.Notes.Where(x => x.Name == note.Name).FirstOrDefault();
                context.Notes.Remove(noteDeleting);
                context.SaveChanges();
                Update();
            }
        }

        public void Edit(Note note, string content)
        {
            using (NoteContext context = new NoteContext())
            {
                var noteTitle = note.Name;
                Note editingNote = context.Notes.Where(x => x.Name == noteTitle).FirstOrDefault();
                editingNote.Content = content;
                context.SaveChanges();
                Update();
            }
        }

        public void Update()
        {
            using (NoteContext context = new NoteContext())
            {
                List<Note> notes = context.Notes.ToList();
                NotesCollectionModel.notesCollection.NotesCollection = new ObservableCollection<Note>(notes);

                messenger.Send(new UpdateMessage(true));
            }
        }

        public void Dump()
        {
            throw new NotImplementedException();
        }
    }
}
