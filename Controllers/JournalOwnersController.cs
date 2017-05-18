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
    [Route("api/[controller]")]
    public class JournalOwnersController : Controller
    {
        private IJournalOwnerRepo m_repo;

        public JournalOwnersController(IJournalOwnerRepo repo){
            m_repo = repo;
        }

        // GET api/JournalOwner
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var owners = await m_repo.GetAllAsync();
            return new ObjectResult(owners);
        }

        // GET api/JournalOwner/1
        [HttpGet("{journalOwnerID}", Name = "JournalOwnerLink")]
        public async Task<IActionResult> Get(int journalOwnerID)
        {
            var owner = await m_repo.GetAsync(journalOwnerID);

            return new ObjectResult(owner);
        }

        // POST api/JournalOwner
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]JournalOwner value)
        {
            // Early return if value is of no use
            if(value == null)
                return BadRequest();

            await m_repo.AddAsync(value);

            // Returns a 201, with a route to the location where the POSTed item can be viewed
            return CreatedAtRoute("JournalOwnerLink", new { journalOwnerID = value.JournalOwnerID }, value);
        }

        // PUT api/JournalOwner/1
        [HttpPut("{journalOwnerID}")]
        public async Task<IActionResult> Put(int journalOwnerID, [FromBody]JournalOwner value)
        {
            // Early return if value is of no use
            if(value == null)
                return BadRequest();

            // Ensure that API surface has the last word on the journalOwnerID
            value.JournalOwnerID = journalOwnerID;                

            await m_repo.UpdateAsync(value);

            return new NoContentResult();
        }

        // DELETE api/JournalOwner/1
        [HttpDelete("{journalOwnerID}")]
        public async Task<IActionResult> Delete(int journalOwnerID)
        {
            await m_repo.DeleteAsync(journalOwnerID);

            return new NoContentResult();
        }
    }
}
