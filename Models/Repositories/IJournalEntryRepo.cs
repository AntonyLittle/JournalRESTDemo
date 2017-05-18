using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BemoRest.Models;


namespace BemoRest.Models.Repositories
{    
    public interface IJournalEntryRepo
    {        
        Task<List<JournalEntry>> GetAllAsync(int journalOwnerID);

        Task<JournalEntry> GetAsync(int journalOwnerID, int entryID);

        Task AddAsync(JournalEntry journalOwner);

        Task UpdateAsync(JournalEntry journalOwner);

        Task DeleteAsync(int journalOwnerID, int entryID);
    }
}