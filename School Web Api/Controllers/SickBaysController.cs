using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.Models.SickBays;
using SchoolWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace School_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SickBaysController : ControllerBase
    {
        private readonly SchoolContext _context;

        public SickBaysController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/SickBays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SickBay>>> GetSickBays()
        {
            return await _context.SickBays.Take(10).ToListAsync();
        }

        // GET: api/SickBays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SickBay>> GetSickBay(int id)
        {
            var sickBay = await _context.SickBays.FindAsync(id);

            if (sickBay == null)
            {
                return NotFound();
            }

            return sickBay;
        }

        // PUT: api/SickBays/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSickBay(int id, SickBay sickBay)
        {
            if (id != sickBay.Id)
            {
                return BadRequest();
            }

            _context.Entry(sickBay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SickBayExists(id))
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

        // POST: api/SickBays
        [HttpPost]
        public async Task<ActionResult<SickBay>> PostSickBay(SickBay sickBay)
        {
            _context.SickBays.Add(sickBay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSickBay", new { id = sickBay.Id }, sickBay);
        }

        // DELETE: api/SickBays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SickBay>> DeleteSickBay(int id)
        {
            var sickBay = await _context.SickBays.FindAsync(id);
            if (sickBay == null)
            {
                return NotFound();
            }

            _context.SickBays.Remove(sickBay);
            await _context.SaveChangesAsync();

            return sickBay;
        }

        private bool SickBayExists(int id)
        {
            return _context.SickBays.Any(e => e.Id == id);
        }
    }
}