using NotesARK6.Model;

namespace NotesARK6.Services
{
    public interface IControllDataBase
    {
        void Add(Note note);
        void Remove(Note note);
        void Edit(Note note, string content);
        void Dump();
    }
}
