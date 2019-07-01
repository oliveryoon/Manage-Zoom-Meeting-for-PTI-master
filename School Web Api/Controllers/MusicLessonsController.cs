using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolWebAPI.Models;
using SchoolWebApi.Models.MusicLessons;

namespace School_Web_Api.Controllers
{
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
            return await _context.MusicLesson.ToListAsync();
        }

        // GET: api/MusicLessons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicLesson>> GetMusicLesson(int id)
        {
            var musicLesson = await _context.MusicLesson.FindAsync(id);

            if (musicLesson == null)
            {
                return NotFound();
            }

            return musicLesson;
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

        // POST: api/MusicLessons
        [HttpPost]
        public async Task<ActionResult<MusicLesson>> PostMusicLesson(MusicLesson musicLesson)
        {
            _context.MusicLesson.Add(musicLesson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicLesson", new { id = musicLesson.Seq }, musicLesson);
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

        private bool MusicLessonExists(int id)
        {
            return _context.MusicLesson.Any(e => e.Seq == id);
        }
    }
}
