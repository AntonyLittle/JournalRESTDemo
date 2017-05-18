using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BemoRest.Models;


namespace BemoRest.Models.Repositories
{    
    public interface IJournalOwnerRepo
    {
        Task<List<JournalOwner>> GetAllAsync();

        Task<JournalOwner> GetAsync(int journalOwnerID);

        Task AddAsync(JournalOwner journalOwner);

        Task UpdateAsync(JournalOwner journalOwner) ;

        Task DeleteAsync(int journalOwnerID);
    }
}