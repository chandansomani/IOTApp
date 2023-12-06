using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IOTAppDashboardAPI.Data;
using IOTAppDashboardAPI.Models;
using IOTAppDashboardAPI.Services;
using IOTAppDashboardAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;

namespace IOTAppDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly DataContext _context;
        public AppUsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AppUsers
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAppUser()
        {
            return await _context.AppUser.ToListAsync();
        }
        
        // GET: api/AppUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetAppUser(int id)
        {
            var appUser = await _context.AppUser.FindAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }
            return appUser;
            
        }
        
        // PUT: api/AppUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(int id, AppUser appUser)
        {
            // The Put method is not working as aspected 
            // It should change only the attributed updated for the 'id' user
            // values not send for attribute gets set to resetted or default value

            if (id != appUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(appUser).State = EntityState.Modified;
            // also need to understand the working of the _context.Entry(....) method
            // scaffolded method.

            // before calling SaveChanges methods on context, 
            // what if futher modified the value of appUser ?
            // all futher secnario can be handled, check the mindmap,

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(id))
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

        // POST: api/AppUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostAppUser(AppUser appUser)
        {
            _context.AppUser.Add(appUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppUser", new { id = appUser.Id }, appUser);
        }

        // DELETE: api/AppUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            var appUser = await _context.AppUser.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            _context.AppUser.Remove(appUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppUserExists(int id)
        {
            return _context.AppUser.Any(e => e.Id == id);
        }

        [HttpGet("ManualSeedData")]
        public  void AppUserManualSeedData()
        {
            _context.ManualSeedData("AppUser");        
            _context.SaveChanges();
        }
    }
}
