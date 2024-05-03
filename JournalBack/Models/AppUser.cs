using System;
using Microsoft.AspNetCore.Identity;
using JournalBack.Data;

namespace JournalBack.Models;

public class User : IdentityUser 
{
    
    public string? FullName { get; set; }
    public ICollection<Journal> Journals { get; } = new List<Journal>();
}