using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BemoRest.Models;
using Microsoft.EntityFrameworkCore;

namespace BemoRest.Models.Repositories
{    
    public class JournalOwnerRepo: IJournalOwnerRepo
    {
        private JournalContext m_context;

        public JournalOwnerRepo(JournalContext context) {
            m_context = context;
        }

        public async Task<List<JournalOwner>> GetAllAsync() {
            return await m_context.JournalOwners.AsNoTracking().ToListAsync();
        }        

        public async Task<JournalOwner> GetAsync(int journalOwnerID) {
            return await m_context.JournalOwners.AsNoTracking().SingleOrDefaultAsync(
                e => e.JournalOwnerID == journalOwnerID
            );
        }

        public async Task AddAsync(JournalOwner journalOwner) {
            m_context.JournalOwners.Add(journalOwner);
            await m_context.SaveChangesAsync();
        }

        public async Task UpdateAsync(JournalOwner journalOwner) {
            m_context.JournalOwners.Update(journalOwner);
            await m_context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int journalOwnerID) {
            var owner = await m_context.JournalOwners.SingleOrDefaultAsync(
                j => j.JournalOwnerID == journalOwnerID
            );
            if(owner != null) {
                m_context.JournalOwners.Remove(owner);
                await m_context.SaveChangesAsync();
            }
        }
    }
}