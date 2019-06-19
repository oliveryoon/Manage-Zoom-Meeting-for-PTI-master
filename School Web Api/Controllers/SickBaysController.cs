using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWebApi.Models.SickBays;
using SchoolWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace School_Web_Api.Controllers
{
    //[Authorize]
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
        [HttpGet("{seq}")]
        public async Task<ActionResult<SickBay>> GetSickBay(int seq)
        {
            var sickBay = await _context.SickBays.FindAsync(seq);

            if (sickBay == null)
            {
                return NotFound();
            }

            return sickBay;
        }

        // GET: api/SickBaysById/5
        [Route("{id:int}/details")]        
        public async Task<ActionResult<SickBay>> GetSickBayDetail(int id)
        {            
            var sickBay = await _context.SickBays.Where(x => x.Id == id && x.TimeOut == null).FirstOrDefaultAsync();

            if (sickBay == null)
            {
                return NotFound();
            }

            return sickBay;
        }


        // PUT: api/SickBays/5
        [HttpPut("{seq}")]
        public async Task<IActionResult> PutSickBay(int seq, SickBay sickBay)
        {
            if (seq != sickBay.Seq)
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
                if (!SickBayExists(seq))
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

        //// POST: api/SickBays
        //[HttpPost]
        //public async Task<ActionResult<SickBay>> PostSickBay(SickBay sickBay)
        //{
        //    _context.SickBays.Add(sickBay);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSickBay", new { id = sickBay.Id }, sickBay);
        //}

        // POST: api/SickBays
        [HttpPost]
        public async Task<ActionResult<SickBay>> PostSickBay(SickBayDTO sickBay)
        {
            _context.UpdateSickBayInOutAsync(sickBay);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSickBay", new { seq = sickBay.Seq }, sickBay);
        }

        // DELETE: api/SickBays/5
        [HttpDelete("{seq}")]
        public async Task<ActionResult<SickBay>> DeleteSickBay(int seq)
        {
            var sickBay = await _context.SickBays.FindAsync(seq);
            if (sickBay == null)
            {
                return NotFound();
            }

            _context.SickBays.Remove(sickBay);
            await _context.SaveChangesAsync();

            return sickBay;
        }

        private bool SickBayExists(int seq)
        {
            return _context.SickBays.Any(e => e.Seq == seq);
        }
    }
}