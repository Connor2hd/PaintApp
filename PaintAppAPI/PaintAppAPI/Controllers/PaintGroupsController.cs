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
    public class PaintGroupsController : ControllerBase
    {
        private readonly PaintContext _context;

        public PaintGroupsController(PaintContext context)
        {
            _context = context;
        }

        // GET: api/PaintGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaintGroup>>> GetPaintGroup()
        {
          if (_context.PaintGroup == null)
          {
              return NotFound();
          }
            return await _context.PaintGroup.ToListAsync();
        }

        // GET: api/PaintGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaintGroup>> GetPaintGroup(Guid id)
        {
          if (_context.PaintGroup == null)
          {
              return NotFound();
          }
            var paintGroup = await _context.PaintGroup.FindAsync(id);

            if (paintGroup == null)
            {
                return NotFound();
            }

            return paintGroup;
        }

        //// PUT: api/PaintGroups/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPaintGroup(Guid id, PaintGroup paintGroup)
        //{
        //    if (id != paintGroup.PaintGroupId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(paintGroup).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PaintGroupExists(id))
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

        //// POST: api/PaintGroups
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<PaintGroup>> PostPaintGroup(PaintGroup paintGroup)
        //{
        //  if (_context.PaintGroup == null)
        //  {
        //      return Problem("Entity set 'PaintContext.PaintGroup'  is null.");
        //  }
        //    _context.PaintGroup.Add(paintGroup);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPaintGroup", new { id = paintGroup.PaintGroupId }, paintGroup);
        //}

        //// DELETE: api/PaintGroups/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePaintGroup(Guid id)
        //{
        //    if (_context.PaintGroup == null)
        //    {
        //        return NotFound();
        //    }
        //    var paintGroup = await _context.PaintGroup.FindAsync(id);
        //    if (paintGroup == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PaintGroup.Remove(paintGroup);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool PaintGroupExists(Guid id)
        {
            return (_context.PaintGroup?.Any(e => e.PaintGroupId == id)).GetValueOrDefault();
        }
    }
}
