using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BemoRest.Models;
using Microsoft.EntityFrameworkCore;
using BemoRest.Models.Repositories;

namespace BemoRest.Controllers
{
    [Route("api/JournalOwners/{journalOwnerID}/Entries")]
    public class JournalEntriesController : Controller
    {
        private IJournalEntryRepo m_repo;

        public JournalEntriesController(IJournalEntryRepo repo)
        {
            m_repo = repo;
        }

        // GET api/JournalOwners/1/Entries
        [HttpGet]
        public async Task<IActionResult> Get(int journalOwnerID)
        {
            var entries = await m_repo.GetAllAsync(journalOwnerID);

            return new ObjectResult(entries);
        }

        // GET api/JournalOwner/1/Entries/2
        [HttpGet("{entryID}")]
        public async Task<IActionResult> Get(int journalOwnerID, int entryID)
        {
            var entry = await m_repo.GetAsync(journalOwnerID, entryID);

            return new ObjectResult(entry);
        }

        // POST api/JournalOwners/1/Entries
        [HttpPost]
        public async Task<IActionResult> Post(int journalOwnerID, [FromBody]JournalEntry value)
        {
            // Early return if value is of no use
            if(value == null)
                return BadRequest();

            // Make sure the data in the URl is reflected in the new entry
            value.JournalOwnerID = journalOwnerID;

            await m_repo.AddAsync(value);

            // Returns a 201, with a route to the location where the POSTed item can be viewed
            return CreatedAtRoute("Entities", new { id = value.JournalEntryID}, value);
        }

        // PUT api/JournalOwners/1/Entries/2
        [HttpPut("{entryID}")]
        public async Task<IActionResult> Put(int journalOwnerID, int entryID, [FromBody]JournalEntry value)
        {
            // Early return if value is of no use
            if(value == null)
                return BadRequest();
            
            // Make sure the data in the URl is reflected in the new entry
            value.JournalOwnerID = journalOwnerID;
            value.JournalEntryID = entryID;

            await m_repo.UpdateAsync(value);

            return new NoContentResult();
        }

        // DELETE api/JournalOwners/1/Entries/2
        [HttpDelete("{entryID}")]
        public async Task<IActionResult> Delete(int journalOwnerID, int entryID)
        {
            await m_repo.DeleteAsync(journalOwnerID, entryID);

            return new NoContentResult();
        }
    }
}
