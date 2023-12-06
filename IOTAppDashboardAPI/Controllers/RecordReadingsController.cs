using IOTAppDashboardAPI.Data;
using IOTAppDashboardAPI.Models;
using IOTAppDashboardAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IOTAppDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordReadingsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public RecordReadingsController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        // POST: api/RecordReadings            // Post Reading Insert Records
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostReading(Readings reading)
        {
            _context.Readings.Add(reading);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostReading", new { id = reading.Id }, reading);
        }

        // GET: api/Reading                     // GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Readings>>> GetReadings()
        {
            return await _context.Readings.ToListAsync();
        }

        // GET: api/Reading/5                   // Get Single Reading
        [HttpGet("{id}")]
        public async Task<ActionResult<Readings>> GetReading(int id)
        {
            var reading = await _context.Readings.FindAsync(id);

            if (reading == null)
            {
                return NotFound();
            }
            return reading;
        }

        // DELETE: api/Reading/5                 // Delete Reading
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReading(int id)
        {
            var reading = await _context.Readings.FindAsync(id);
            if (reading == null)
            {
                return NotFound();
            }

            _context.Readings.Remove(reading);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Reading/5                       // Edit Modify Reading
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReading(int id, Readings reading)
        {
            // The Put method is not working as aspected 
            // It should change only the attributed updated for the 'id' reading
            // values not send for attribute gets set to resetted or default value

            if (id != reading.Id)
            {
                return BadRequest();
            }

            _context.Entry(reading).State = EntityState.Modified;
            // also need to understand the working of the _context.Entry(....) method
            // scaffolded method.

            // before calling SaveChanges methods on context, 
            // what if futher modified the value of reading ?
            // all futher secnario can be handled, check the mindmap,

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReadingExists(id))
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

        private bool ReadingExists(int id)
        {
            return _context.Readings.Any(e => e.Id == id);
        }
    }
}
