using System;

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

        

        public async Task<Journal?> DeleteAsync(int id)
        {
            var journal = await _context.Journals.FirstOrDefaultAsync(x => x.Id == id);

            if(journal == null)
            {
                return null;

            }
            _context.Journals.Remove(journal);
            await _context.SaveChangesAsync();

            return journal;
        }

       

        public async Task<List<Journal>> GetAllAsync()
        {
            return await _context.Journals.Include(a => a.AppUser).ToListAsync();
        }

        public async Task<Journal?> GetByIdAsync(int id)
        {
            return await _context.Journals.Include(a => a.AppUser).FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<Journal?> UpdateAsync(int id, Journal journal)
        {
            var existingJournal = await _context.Journals.FindAsync(id);

            if(existingJournal == null)
            {
                return null;
            }

            existingJournal.Title = journal.Title;
            existingJournal.Content = journal.Content;

            await _context.SaveChangesAsync();

            return existingJournal;
        }
    }
}