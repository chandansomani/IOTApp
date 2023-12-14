using IOTAppDashboardAPI.Data;
using IOTAppDashboardAPI.Models;
using IOTAppDashboardAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IOTAppDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService tokenService;

        public DeviceController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            this.tokenService = tokenService;
        }

        // GET: api/Devices             // GetAll
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }

        [HttpGet("GetAllDevices/{Info}")]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevicesInfo(string Info)
        {
            switch (Info)
            {
                case "Id":
                    //return await _context.Devices.Select(id => id.Id).ToListAsync();                    
                    return await _context.Devices.ToListAsync();                    

                default: 
                    return await _context.Devices.ToListAsync();
            }
        }

        // GET: api/Devices/5           // Get Single
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }
            return device;
        }



        // POST: api/Devices            // Create
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostDevice(Device device)
        {
            
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostDevice", new { id = device.Id }, device);
        }

        // DELETE: api/Devices/5        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // PUT: api/Devices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, Device device)
        {
            // The Put method is not working as aspected 
            // It should change only the attributed updated for the 'id' device
            // values not send for attribute gets set to resetted or default value

            if (id != device.Id)
            {
                return BadRequest();
            }

            _context.Entry(device).State = EntityState.Modified;
            // also need to understand the working of the _context.Entry(....) method
            // scaffolded method.

            // before calling SaveChanges methods on context, 
            // what if futher modified the value of device ?
            // all futher secnario can be handled, check the mindmap,

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
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

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.Id == id);
        }


        [HttpGet("ManualSeedData")]
        public void AppUserManualSeedData()
        {
            _context.ManualSeedData("Devices");
            _context.SaveChanges();
        }
    }
}
