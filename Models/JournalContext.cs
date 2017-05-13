using Microsoft.EntityFrameworkCore;

namespace BemoRest.Models
{
    public class JournalContext : DbContext  
    {
        public JournalContext(){}

        public JournalContext(DbContextOptions<JournalContext> options)
            : base(options)
        { }

        public DbSet<JournalOwner> JournalOwners { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Filename=./journals.sqlite");
        }        
    }
}