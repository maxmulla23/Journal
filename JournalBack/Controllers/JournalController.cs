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
using Microsoft.EntityFrameworkCore.Metadata.Internal;



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
            var userJournal = await _journalRepo.GetUserJournal(appUser);

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
      [Authorize]
      public async Task<IActionResult> CreateJournal( CreateJournalDto createjournalDto)
      {

        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
    
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);


        var journalModel = createjournalDto.ToJournalFromCreate();
        journalModel.AppUserId = appUser.Id;
        await _journalRepo.CreateAsync(journalModel);

        return CreatedAtAction(nameof(GetById), new { id = journalModel.Id}, journalModel.ToJournalDto());
        
       
      }

    [HttpPut]
    [Route("{id:int}")]
    
    public async Task<IActionResult> EditJournal([FromRoute] int id, [FromBody] UpdateJournalDto updateJournal)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);


        var journal = await _journalRepo.UpdateAsync(id, updateJournal.ToJournalFromUpdate());

        if(journal == null)
        {
            return NotFound("Journal does not exist");
        }

        return Ok(journal.ToJournalDto());


    }

    [HttpDelete]
    [Route("{id:int}")]
    
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if(!ModelState.IsValid)
            return BadRequest();


        var journal = await _journalRepo.DeleteAsync(id);

        if  (journal == null)
        {
            return NotFound();
        }
        return Ok(journal);
    }

    }

    
}