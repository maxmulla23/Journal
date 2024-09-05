using System;
using System.Configuration;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using JournalBack.Data;
using JournalBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using JournalBack.Dtos.Account;
using JournalBack.Interfaces;


namespace JoournalBack.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class UserController : ControllerBase
    {
           public readonly JournalDbContext _context;
         private readonly UserManager<AppUser> _userManager;
         private readonly ITokenService _tokenService;
         private readonly SignInManager<AppUser> _signInManager;
    //     private readonly IConfiguration _configuration;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, JournalDbContext context, ITokenService tokenService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            
        }

   

   [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registerDto.UserName,
                    FullName = registerDto.FullName,
                    Email = registerDto.Email
                };
                var createUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if(createUser.Succeeded)
                {
                    var roleresult = await _userManager.AddToRoleAsync(appUser, "User");
                    if(roleresult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                FullName = appUser.FullName,
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = _tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    else 
                    {
                        return StatusCode(500, roleresult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createUser.Errors);
                }
            }
            catch (Exception e)
            {
                
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login (LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

            if(user == null) return Unauthorized("Invalid Username!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded) return Unauthorized("Username not found and/or password is incorrect!");

            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                }
            );
        }
    }
}