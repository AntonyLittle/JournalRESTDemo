namespace BemoRest.Models
{
    public class JournalEntry
    {
        public int JournalEntryID {get;set;}
        public int JournalOwnerID {get;set;}
        public string JournalText {get;set;}

        public JournalOwner JournalOwner {get;set;}
    }
}