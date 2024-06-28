using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalBack.Models;

namespace JournalBack.Interfaces
{
    public interface IJournalRepository
    {
        Task<List<Journal>> GetAllAsync(AppUser user);
        // Task<Journal?> GetByIdAsync(int id);
        Task<Journal> CreateAsync(Journal journal);
        Task<Journal?> UpdateAsync(int id, Journal journal);
        Task<Journal?> DeleteAsync(AppUser appUser);
    }
}