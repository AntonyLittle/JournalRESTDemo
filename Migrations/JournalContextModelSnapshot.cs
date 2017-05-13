using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BemoRest.Models;

namespace BemoRest.Migrations
{
    [DbContext(typeof(JournalContext))]
    partial class JournalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("BemoRest.Models.JournalEntry", b =>
                {
                    b.Property<int>("JournalEntryID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("JournalOwnerID");

                    b.Property<string>("JournalText");

                    b.HasKey("JournalEntryID");

                    b.HasIndex("JournalOwnerID");

                    b.ToTable("JournalEntries");
                });

            modelBuilder.Entity("BemoRest.Models.JournalOwner", b =>
                {
                    b.Property<int>("JournalOwnerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("JournalOwnerID");

                    b.ToTable("JournalOwners");
                });

            modelBuilder.Entity("BemoRest.Models.JournalEntry", b =>
                {
                    b.HasOne("BemoRest.Models.JournalOwner", "JournalOwner")
                        .WithMany("JournalEntrys")
                        .HasForeignKey("JournalOwnerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
