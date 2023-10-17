using IOTAppDashboardAPI.Data;
using IOTAppDashboardAPI.Models;
using IOTAppDashboardAPI.Models.Dto;
using IOTAppDashboardAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IOTAppDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public LoginController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost] // /api/LoginAppUser
        public async Task<ActionResult<String>> LoginAppUser(LoginDto appUser)
        {
            //AppUser User = await _context.AppUser.FindAsync(appUser.UserName);
            AppUser User = await _context.AppUser
                .Where(x => x.UserName == appUser.UserName)
                .FirstOrDefaultAsync();


            // The above comparision is comparing caseInsensitive
            //Todo : Search Bug

            if (User == null)
            {
                return NotFound();
            }
            else
            {
                var passhash = Utilities.HashPass(appUser.Password);

                for (int i = 0; i < User.PasswordHash.Length; i++)
                {
                    if (User.PasswordHash[i] != passhash[i]) return Unauthorized("Invalid Password.");
                }

                return Ok(new { token = _tokenService.CreateToken(User)});
            }
        }
    }
}
