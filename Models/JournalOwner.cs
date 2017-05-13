using System.Collections.Generic;

namespace BemoRest.Models
{
    public class JournalOwner
    {
        public int JournalOwnerID {get;set;}
        public string Name {get;set;}

        public List<JournalEntry> JournalEntrys {get;set;} = new List<JournalEntry>();
    }
}