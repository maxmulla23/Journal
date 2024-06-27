using System;
using Microsoft.AspNetCore.Identity;
using JournalBack.Data;

namespace JournalBack.Models;

public class AppUser : IdentityUser 
{
    
    public string? FullName { get; set; }
    // public ICollection<Journal> Journals { get; } = new List<Journal>();
}