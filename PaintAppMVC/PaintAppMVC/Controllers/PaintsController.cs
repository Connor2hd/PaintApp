using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaintAppModels;

namespace PaintAppMVC.Controllers
{
    public class PaintsController : Controller
    {
        private readonly PaintContext _context;

        public PaintsController(PaintContext context)
        {
            _context = context;
        }

        // GET: Paints
        public async Task<IActionResult> Index()
        {
              return _context.Paint != null ? 
                          View(await _context.Paint.ToListAsync()) :
                          Problem("Entity set 'PaintContext.PaintItems'  is null.");
        }

        // GET: Paints/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Paint == null)
            {
                return NotFound();
            }

            var paint = await _context.Paint
                .FirstOrDefaultAsync(m => m.PaintId == id);
            if (paint == null)
            {
                return NotFound();
            }

            return View(paint);
        }

        // GET: Paints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaintId,GroupId,PaintName,PaintSize,StockImageURL,MSRP")] Paint paint)
        {
            if (ModelState.IsValid)
            {
                paint.PaintId = Guid.NewGuid();
                _context.Add(paint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paint);
        }

        // GET: Paints/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Paint == null)
            {
                return NotFound();
            }

            var paint = await _context.Paint.FindAsync(id);
            if (paint == null)
            {
                return NotFound();
            }
            return View(paint);
        }

        // POST: Paints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PaintId,GroupId,PaintName,PaintSize,StockImageURL,MSRP")] Paint paint)
        {
            if (id != paint.PaintId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaintExists(paint.PaintId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paint);
        }

        // GET: Paints/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Paint == null)
            {
                return NotFound();
            }

            var paint = await _context.Paint
                .FirstOrDefaultAsync(m => m.PaintId == id);
            if (paint == null)
            {
                return NotFound();
            }

            return View(paint);
        }

        // POST: Paints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Paint == null)
            {
                return Problem("Entity set 'PaintContext.PaintItems'  is null.");
            }
            var paint = await _context.Paint.FindAsync(id);
            if (paint != null)
            {
                _context.Paint.Remove(paint);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaintExists(Guid id)
        {
          return (_context.Paint?.Any(e => e.PaintId == id)).GetValueOrDefault();
        }
    }
}
