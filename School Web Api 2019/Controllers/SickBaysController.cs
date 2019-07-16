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
    [Authorize(Roles = "sec.All Staff")]
    [Authorize]
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
            return await _context.SickBays.Take(10).OrderBy(x=>x.IncidentDate).ThenBy(x=>x.TimeIn).ThenBy(x=>x.TimeOut).ToListAsync();
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
        // GET: api/SickBays/5/detail
        [Route("detail/{id:int}")]
        public async Task<ActionResult<SickBay>> GetSickBayDetail(int id)
        {
            var sickBay = await _context.SickBays.Where(x => x.Id == id && x.TimeOut == new TimeSpan()).FirstOrDefaultAsync();

            if (sickBay == null)
            {
                return NotFound();
            }

            return sickBay;
        }
        // GET: api/SickBays/5/detail
        // Incident Details by ID.
        [Route("{id:int}/detailById")]        
        public async Task<ActionResult<SickBay>> GetSickBayDetailByID(int id)
        {            
            var sickBay = await _context.SickBays.Where(x => x.Id == id && x.TimeOut == new TimeSpan()).FirstOrDefaultAsync();

            if (sickBay == null)
            {
                return NotFound();
            }

            return sickBay;
        }
        // GET: api/SickBays/5/StatusById
        // This will return the current acceptable sick bay status by student Id.
        [Route("{id:int}/StatusById")]
        public async Task<ActionResult<SickBayStatusDTO>> GetSickBayStatusByID(int id)
        {
            

            try
            {

                SickBayStatusDTO dto = _context.GetSickBayStatusAsync(id);
                await _context.SaveChangesAsync();
                return dto;
                
                ////var sickBay = await _context.SickBays.Where(x => x.Id == id).OrderByDescending(x => x.DateModified).FirstOrDefaultAsync();
                //////var sickBay = await _context.SickBays.Where(x => x.Id == id && x.TimeOut == new TimeSpan()).FirstOrDefaultAsync();

                ////// P => Pending Check out because he signed in yesterday or before. The student must check out first. 
                ////// I=> It is ok to sign in.
                ////// O=> It is ok to sign out.

                ////dto.Id = id;
                ////if (sickBay != null && (System.DateTime.Now.Ticks - sickBay.DateModified.Ticks) <= 20)
                ////{
                ////    dto.Code = "ER";
                ////    dto.Description = "Scaned just. Please try again later.";
                ////}
                ////else if (sickBay == null || sickBay.TimeIn != new TimeSpan() && sickBay.TimeOut != new TimeSpan())
                ////{
                ////    dto.Code = "SI";
                ////    dto.Description = "Sign In";
                ////}
                ////else if (sickBay.IncidentDate.Day != DateTime.Now.Day) //not at the same day, then a nurse must have a look at it.
                ////{
                ////    dto.Code = "ER";
                ////    dto.Description = "Overdue. Please see a nurse for sign out first.";
                ////}
                ////else
                ////{
                ////    dto.Code = "SO";
                ////    dto.Description = "Sign Out";
                ////}

                ////return dto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
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
        // Create a sick bay entry in Synergetic and sign out a student as well.
        [HttpPost]
        public async Task<ActionResult<SickBay>> PostSickBay(SickBayDTO sickBay)
        {
            try
            {
                _context.UpdateSickBaySignInOutAsync(sickBay);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetSickBay", new { seq = sickBay.Seq }, sickBay);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                //return new SickBay { Id = 0, DateModified = DateTime.Now, IncidentDate = DateTime.Now, Seq = 0, TimeIn = new TimeSpan(), TimeOut = new TimeSpan(), UsernameModified = e.Message.Substring(50) };
            }
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