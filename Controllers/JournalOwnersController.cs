using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BemoRest.Models;
using Microsoft.EntityFrameworkCore;

namespace BemoRest.Controllers
{
    [Route("api/[controller]")]
    public class JournalOwnersController : Controller
    {
        // GET api/JournalOwner
        [HttpGet]
        public async Task<IEnumerable<JournalOwner>> Get()
        {
            using(var context = new JournalContext()) {
                return await context.JournalOwners.ToListAsync();
            }   
        }

        // GET api/JournalOwner/1
        [HttpGet("{journalOwnerID}")]
        public async Task<JournalOwner> Get(int journalOwnerID)
        {
            using(var context = new JournalContext()) {
                return await context.JournalOwners.SingleOrDefaultAsync(
                    e => e.JournalOwnerID == journalOwnerID
                );
            }            
        }

        // POST api/JournalOwner
        [HttpPost]
        public async void Post([FromBody]JournalOwner value)
        {
            using(var context = new JournalContext()) {
                context.JournalOwners.Add(value);
                await context.SaveChangesAsync();
            }
        }

        // PUT api/JournalOwner/1
        [HttpPut("{journalOwnerID}")]
        public async void Put(int journalOwnerID, [FromBody]JournalOwner value)
        {
            value.JournalOwnerID = journalOwnerID;

            using(var context = new JournalContext()) {
                context.JournalOwners.Update(value);
                await context.SaveChangesAsync();
            }
        }

        // DELETE api/JournalOwner/1
        [HttpDelete("{journalOwnerID}")]
        public async void Delete(int journalOwnerID)
        {
            using(var context = new JournalContext()) {
                var owner = await context.JournalOwners.SingleOrDefaultAsync(
                    j => j.JournalOwnerID == journalOwnerID
                );
                if(owner != null) {
                    context.JournalOwners.Remove(owner);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
