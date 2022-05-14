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
    public class PaintsController : ControllerBase
    {
        private readonly PaintContext _context;

        public PaintsController(PaintContext context)
        {
            _context = context;
        }

        // GET: api/Paints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paint>>> GetPaintItems()
        {
          if (_context.PaintItems == null)
          {
              return NotFound();
          }
            return await _context.PaintItems.ToListAsync();
        }

        // GET: api/Paints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paint>> GetPaint(Guid id)
        {
          if (_context.PaintItems == null)
          {
              return NotFound();
          }
            var paint = await _context.PaintItems.FindAsync(id);

            if (paint == null)
            {
                return NotFound();
            }

            return paint;
        }

        //// PUT: api/Paints/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPaint(Guid id, Paint paint)
        //{
        //    if (id != paint.PaintId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(paint).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PaintExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Paints
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Paint>> PostPaint(Paint paint)
        //{
        //  if (_context.PaintItems == null)
        //  {
        //      return Problem("Entity set 'PaintContext.PaintItems'  is null.");
        //  }
        //    _context.PaintItems.Add(paint);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPaint", new { id = paint.PaintId }, paint);
        //}

        //// DELETE: api/Paints/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePaint(Guid id)
        //{
        //    if (_context.PaintItems == null)
        //    {
        //        return NotFound();
        //    }
        //    var paint = await _context.PaintItems.FindAsync(id);
        //    if (paint == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PaintItems.Remove(paint);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool PaintExists(Guid id)
        {
            return (_context.PaintItems?.Any(e => e.PaintId == id)).GetValueOrDefault();
        }
    }
}
