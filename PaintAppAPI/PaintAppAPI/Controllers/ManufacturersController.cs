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
    public class ManufacturersController : ControllerBase
    {
        private readonly PaintContext _context;

        public ManufacturersController(PaintContext context)
        {
            _context = context;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturer()
        {
          if (_context.Manufacturer == null)
          {
              return NotFound();
          }
            return await _context.Manufacturer.ToListAsync();
        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturer(Guid id)
        {
          if (_context.Manufacturer == null)
          {
              return NotFound();
          }
            var manufacturer = await _context.Manufacturer.FindAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return manufacturer;
        }

        //// PUT: api/Manufacturers/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutManufacturer(Guid id, Manufacturer manufacturer)
        //{
        //    if (id != manufacturer.ManufacturerId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(manufacturer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ManufacturerExists(id))
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

        //// POST: api/Manufacturers
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Manufacturer>> PostManufacturer(Manufacturer manufacturer)
        //{
        //  if (_context.Manufacturer == null)
        //  {
        //      return Problem("Entity set 'PaintContext.Manufacturer'  is null.");
        //  }
        //    _context.Manufacturer.Add(manufacturer);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetManufacturer", new { id = manufacturer.ManufacturerId }, manufacturer);
        //}

        //// DELETE: api/Manufacturers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteManufacturer(Guid id)
        //{
        //    if (_context.Manufacturer == null)
        //    {
        //        return NotFound();
        //    }
        //    var manufacturer = await _context.Manufacturer.FindAsync(id);
        //    if (manufacturer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Manufacturer.Remove(manufacturer);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool ManufacturerExists(Guid id)
        {
            return (_context.Manufacturer?.Any(e => e.ManufacturerId == id)).GetValueOrDefault();
        }
    }
}
