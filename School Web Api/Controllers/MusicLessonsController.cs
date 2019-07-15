using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolWebAPI.Models;
using SchoolWebApi.Models.MusicLessons;
using Microsoft.AspNetCore.Authorization;

namespace School_Web_Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MusicLessonsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public MusicLessonsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/MusicLessons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicLesson>>> GetMusicLesson()
        {
            return await _context.MusicLesson.OrderBy(x =>x.Id).ThenBy(x=> x.StaffScheduleDateTimeFrom).ThenBy(x => x.DateTimeIn).ToListAsync();
        }
        // GET: api/MusicLessons/5
        [HttpGet("{seq}")]
        public async Task<ActionResult<MusicLesson>> GetMusicLesson(int seq)
        {
            var musicLesson = await _context.MusicLesson.FindAsync(seq);

            if (musicLesson == null)
            {
                return NotFound();
            }

            return musicLesson;
        }
        // GET: api/MusicLessons/5
        //[Route("detail/{id:int}")]
        [HttpGet("detail/{id:int}")]
        public async Task<ActionResult<MusicLesson>> GetMusicLessonDetailById(int id)
        {
            var musicLesson = await _context.MusicLesson.Where(x=>x.Id == id).FirstOrDefaultAsync();

            if (musicLesson == null)
            {
                return NotFound();
            }

            return musicLesson;
        }
        // GET: api/MusicLessons/5/StatusById
        // This will return the current acceptable sick bay status by student Id.       
        [HttpGet]
        [Route("status")]
        public async Task<ActionResult<MusicLessonStatusDTO>> GetMusicLesson([FromQuery] MusicLessonStatusDTO status)
        {


            try
            {

                MusicLessonStatusDTO dto = _context.GetMusicLessonStatusAsync(status);
                await _context.SaveChangesAsync();
                return dto;
               
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        // GET: api/MusicLessons/5/StatusById
        // This will return the current acceptable sick bay status by student Id.       
        [HttpGet]
        [Route("absencestatus")]
        public async Task<ActionResult<MusicLessonStatusDTO>> GetMusicLessonAbsence([FromQuery] MusicLessonStatusDTO status)
        {


            try
            {

                MusicLessonStatusDTO dto = _context.GetMusicLessonAbsenceStatusAsync(status);
                await _context.SaveChangesAsync();
                return dto;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        // PUT: api/MusicLessons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicLesson(int id, MusicLesson musicLesson)
        {
            if (id != musicLesson.Seq)
            {
                return BadRequest();
            }

            _context.Entry(musicLesson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicLessonExists(id))
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

        //// POST: api/MusicLessons
        //[HttpPost]
        //public async Task<ActionResult<MusicLesson>> PostMusicLesson(MusicLesson musicLesson)
        //{
        //    _context.MusicLesson.Add(musicLesson);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMusicLesson", new { id = musicLesson.Seq }, musicLesson);
        //}

        // POST: api/MusicLessons
        // Create a music lesson entry in Synergetic and sign out a student as well.
        [HttpPost]
        public async Task<ActionResult<MusicLesson>> PostMusicLesson(MusicLessonDTO musicLesson)
        {
            try
            {
                _context.UpdateMusicLessonSignInOutAsync(musicLesson);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMusicLesson", new { seq = musicLesson.Seq }, musicLesson);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                
            }
        }
        [HttpPost]
        [Route("MusicLessonAbsence")]
        public async Task<ActionResult<MusicLesson>> PostMusicLessonAbsence(MusicLessonDTO musicLesson)
        {
            try
            {
                _context.UpdateMusicLessonAbsenceSignInOutAsync(musicLesson);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMusicLesson", new { seq = musicLesson.Seq }, musicLesson);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
        // DELETE: api/MusicLessons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MusicLesson>> DeleteMusicLesson(int id)
        {
            var musicLesson = await _context.MusicLesson.FindAsync(id);
            if (musicLesson == null)
            {
                return NotFound();
            }

            _context.MusicLesson.Remove(musicLesson);
            await _context.SaveChangesAsync();

            return musicLesson;
        }

        private bool MusicLessonExists(int seq)
        {
            return _context.MusicLesson.Any(e => e.Seq == seq);
        }
    }
}
