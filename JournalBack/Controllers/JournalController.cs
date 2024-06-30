using System;
using System.Security.Claims;
using JournalBack.Data;
using JournalBack.Dtos.Journal;
using JournalBack.Extensions;
using JournalBack.Interfaces;
using JournalBack.Models;
using JournalBack.Mappers;
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
        private readonly IJournalRepository _journalRepo;
        private readonly UserManager<AppUser> _userManager;

        public JournalController(IJournalRepository journalRepo, UserManager<AppUser> userManager)
        {
            _journalRepo = journalRepo;
            _userManager = userManager;
        }

        [HttpGet]
    
        public async Task<IActionResult> GetAllUserJournal()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userJournal = await _journalRepo.GetAllAsync();

            if(userJournal == null)
            {
                return NoContent();
            }

            return Ok(userJournal);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var journal = await _journalRepo.GetByIdAsync(id);

            if (journal == null)
            {
                return NotFound();
            }

            return Ok(journal.ToJournalDto());
        }
      
      [HttpPost]
      
      public async Task<IActionResult> CreateJournal(CreateJournalDto journalDto)
      {

        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
    
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);


        var journalModel = journalDto.ToJournalFromCreate();
        journalModel.AppUserId = appUser.Id;
        
        
        await _journalRepo.CreateAsync(journalModel);

        return CreatedAtAction(nameof(GetById), new { id = journalModel.Id}, journalModel.ToJournalDto());
        
       
      }
    }
}