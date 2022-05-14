using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaintAppModels;

namespace PaintAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPaintsController : ControllerBase
    {
        private readonly PaintContext _context;

        public UserPaintsController(PaintContext context)
        {
            _context = context;
        }

        // GET: api/UserPaints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPaint>>> GetUserPaint()
        {
          if (_context.UserPaint == null)
          {
              return NotFound();
          }
            return await _context.UserPaint.ToListAsync();
        }

        // GET: api/UserPaints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPaint>> GetUserPaint(Guid id)
        {
          if (_context.UserPaint == null)
          {
              return NotFound();
          }
            var userPaint = await _context.UserPaint.FindAsync(id);

            if (userPaint == null)
            {
                return NotFound();
            }

            return userPaint;
        }

        // PUT: api/UserPaints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPaint(Guid id, UserPaint userPaint)
        {
            if (id != userPaint.UserPaintId)
            {
                return BadRequest();
            }

            _context.Entry(userPaint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPaintExists(id))
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

        // POST: api/UserPaints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserPaint>> PostUserPaint(UserPaint userPaint)
        {
          if (_context.UserPaint == null)
          {
              return Problem("Entity set 'PaintContext.UserPaint'  is null.");
          }
            _context.UserPaint.Add(userPaint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPaint", new { id = userPaint.UserPaintId }, userPaint);
        }

        // DELETE: api/UserPaints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPaint(Guid id)
        {
            if (_context.UserPaint == null)
            {
                return NotFound();
            }
            var userPaint = await _context.UserPaint.FindAsync(id);
            if (userPaint == null)
            {
                return NotFound();
            }

            _context.UserPaint.Remove(userPaint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserPaintExists(Guid id)
        {
            return (_context.UserPaint?.Any(e => e.UserPaintId == id)).GetValueOrDefault();
        }
    }
}
