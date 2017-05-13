using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BemoRest.Models;
using Microsoft.EntityFrameworkCore;

namespace BemoRest.Controllers
{
    [Route("api/JournalOwners/{journalOwnerID}/Entries")]
    public class JournalEntriesController : Controller
    {
        // GET api/JournalOwners/1/Entries
        [HttpGet]
        public async Task<IEnumerable<JournalEntry>> Get(int journalOwnerID)
        {
            using(var context = new JournalContext()) {
                return await context.JournalEntries.Where(
                    e => e.JournalOwnerID == journalOwnerID
                ).ToListAsync();
            }            
        }

        // GET api/JournalOwner/1/Entries/2
        [HttpGet("{entryID}")]
        public async Task<JournalEntry> Get(int journalOwnerID, int entryID)
        {
            using(var context = new JournalContext()) {
                return await context.JournalEntries.SingleOrDefaultAsync(
                    e => e.JournalOwnerID == journalOwnerID
                        && e.JournalEntryID == entryID
                );
            }
        }

        // POST api/JournalOwners/1/Entries
        [HttpPost]
        public async void Post(int journalOwnerID, [FromBody]JournalEntry value)
        {
            // Make sure the data in the URl is reflected in the new entry
            value.JournalOwnerID = journalOwnerID;

            using(var context = new JournalContext()) {
                context.JournalEntries.Add(value);
                await context.SaveChangesAsync();
            }
        }

        // PUT api/JournalOwners/1/Entries/2
        [HttpPut("{entryID}")]
        public async void Put(int journalOwnerID, int entryID, [FromBody]JournalEntry value)
        {
            // Make sure the data in the URl is reflected in the new entry
            value.JournalOwnerID = journalOwnerID;
            value.JournalEntryID = entryID;

            using(var context = new JournalContext()) {
                context.JournalEntries.Update(value);
                await context.SaveChangesAsync();
            }            
        }

        // DELETE api/JournalOwners/1/Entries/2
        [HttpDelete("{entryID}")]
        public async void Delete(int journalOwnerID, int entryID)
        {
            using(var context = new JournalContext()) {
                var entry = context.JournalEntries.SingleOrDefault(
                    e => e.JournalOwnerID == journalOwnerID
                        && e.JournalEntryID == entryID
                );
                if(entry != null) {
                    context.JournalEntries.Remove(entry);
                    await context.SaveChangesAsync();
                }
            }            
        }
    }
}
