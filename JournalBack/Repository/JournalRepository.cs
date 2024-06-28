using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalBack.Data;
using JournalBack.Interfaces;
using JournalBack.Models;
using Microsoft.EntityFrameworkCore;

namespace JournalBack.Repository
{
    public class JournalRepository : IJournalRepository
    {
        private readonly JournalDbContext _context;

        public JournalRepository(JournalDbContext context)
        {
            _context = context;
        }
        public async Task<Journal> CreateAsync(Journal journal)
        {
            await _context.Journals.AddAsync(journal);
            await _context.SaveChangesAsync();

            return journal;
        }

        

        public Task<Journal?> DeleteAsync(AppUser appUser)
        {
            throw new NotImplementedException();
        }

       

        public async Task<List<Journal>> GetAllAsync(AppUser user)
        {
            return await _context.Journals.Where(u => u.AppUserId == user.Id)
            .Select(journal => new Journal
            {
                Id = journal.Id,
                Date = journal.Date,
                Title = journal.Title,
                Content = journal.Content,
                
            }).ToListAsync();
        }

        

        public Task<Journal?> UpdateAsync(int id, Journal journal)
        {
            throw new NotImplementedException();
        }
    }
}