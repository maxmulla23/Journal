using System;
using JournalBack.Data;
using JournalBack.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace JournalBack.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class JournalController : ControllerBase
    {
        private readonly JournalDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public JournalController(JournalDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager= userManager;
           
        }

        [HttpPost]
        public async Task<IActionResult> PostJournal([FromBody] Journal model)
        {

            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            
         try
         {
            Journal journal = new Journal()
            {
                Title = model.Title,
                Content = model.Content,
                UserId = user.Id
            };
           
            // journal.User = _user;
            var result = await _dbContext.Journals.AddAsync(journal);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJournal), new { id = journal.Id}, journal);
         }
         catch (Exception ex)
         { 

            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
            
         }
        }

        [HttpGet]
        [Route("user/{userId}")]
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