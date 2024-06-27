using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JournalBack.Models;

namespace JournalBack.Data 
{
    public class JournalDbContext : IdentityDbContext<AppUser>
    {

        public JournalDbContext(DbContextOptions<JournalDbContext> options) : base(options) { }
        
        public DbSet<Journal> Journals { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName= "USER"},
            };
            
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}