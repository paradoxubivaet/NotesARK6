namespace NotesARK6.Messages
{
    public class NotificationMessage
    {
        public bool Flag { get; }
        public NotificationMessage(bool flag)
        {
            Flag = flag;
        }
    }
}
