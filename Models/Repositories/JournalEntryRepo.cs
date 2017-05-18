using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BemoRest.Models;
using Microsoft.EntityFrameworkCore;

namespace BemoRest.Models.Repositories
{    
    public class JournalEntryRepo: IJournalEntryRepo
    {
        private JournalContext m_context;

        public JournalEntryRepo(JournalContext context) {
            m_context = context;
        }

        public async Task<List<JournalEntry>> GetAllAsync(int journalOwnerID) {
            return await m_context.JournalEntries.AsNoTracking().Where(
                e => e.JournalOwnerID == journalOwnerID
            ).ToListAsync();
        }        

        public async Task<JournalEntry> GetAsync(int journalOwnerID, int entryID) {
            return await m_context.JournalEntries.AsNoTracking().SingleOrDefaultAsync(
                e => e.JournalOwnerID == journalOwnerID
                    && e.JournalEntryID == entryID
            );
        }

        public async Task AddAsync(JournalEntry journalEntry) {
            m_context.JournalEntries.Add(journalEntry);
            await m_context.SaveChangesAsync();
        }

        public async Task UpdateAsync(JournalEntry journalEntry) {
            m_context.JournalEntries.Update(journalEntry);
            await m_context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int journalOwnerID, int entryID) {
            var entry = m_context.JournalEntries.SingleOrDefault(
                e => e.JournalOwnerID == journalOwnerID
                    && e.JournalEntryID == entryID
            );
            if(entry != null) {
                m_context.JournalEntries.Remove(entry);
                await m_context.SaveChangesAsync();
            }
        }
    }
}