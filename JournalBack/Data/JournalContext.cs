using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JournalBack.Models;

namespace JournalBack.Data 
{
    public class JournalDbContext : IdentityDbContext<User>
    {

        public JournalDbContext(DbContextOptions<JournalDbContext> options) : base(options) { }
        
        public DbSet<Journal> Journals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Journal>()
            .HasOne(j => j.User)
            .WithMany(u => u.Journals)
            .HasForeignKey(j => j.UserId)
            .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}