using System;
using JournalBack.Data;
using JournalBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace JournalBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class JournalController : ControllerBase
    {
        private readonly JournalDbContext _dbContext;

        public JournalController(JournalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostJournal(Journal journal)
        {
         try
         {
               _dbContext.Journals.Add(journal);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(PostJournal), new { id = journal.Id}, journal);
         }
         catch (System.Exception)
         {
            
            throw;
         }
        }

        [HttpGet]
        [Route("user/{userId}/journals")]
        public async Task<IActionResult> GetJournal(string userId)
        {
            try
            {
                var journals = await _dbContext.Journals.Where(j => j.UserId == userId).ToListAsync();

                if (journals == null || journals.Count == 0)
                {
                    return NotFound();
                }
                return Ok(journals);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("id")]
        public async Task<IActionResult> PutJournal(int id, Journal journal)
        {
            if (id != journal.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(journal).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync(); 
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!JournalExists(id))
                {
                    return NotFound();
                }
                else 
                {
                throw;
                }
            }
           

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteJournal(int id)
        {
            var journal = await _dbContext.Journals.FindAsync(id);
            if (journal == null)
            {
                return NotFound();
            }
            _dbContext.Journals.Remove(journal);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        private bool JournalExists(int id)   //Checks if journal already exists
        {
            return _dbContext.Journals.Any(e => e.Id == id);
        }
        [HttpGet]
        public async Task<IActionResult> GetJournal() //get all journals 
        {
            var journals = await _dbContext.Journals.ToListAsync();
            if(journals == null)
            {
                return NotFound();
            }

            return Ok(journals);
        }
    }
}