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
    public class PaintGroupsController : Controller
    {
        private readonly PaintContext _context;

        public PaintGroupsController(PaintContext context)
        {
            _context = context;
        }

        // GET: PaintGroups
        public async Task<IActionResult> Index()
        {
              return _context.PaintGroup != null ? 
                          View(await _context.PaintGroup.ToListAsync()) :
                          Problem("Entity set 'PaintContext.PaintGroup'  is null.");
        }

        // GET: PaintGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.PaintGroup == null)
            {
                return NotFound();
            }

            var paintGroup = await _context.PaintGroup
                .FirstOrDefaultAsync(m => m.PaintGroupId == id);
            if (paintGroup == null)
            {
                return NotFound();
            }

            return View(paintGroup);
        }

        // GET: PaintGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaintGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaintGroupId,ManufacturerId,PaintGroupName,PaintGroupDescription")] PaintGroup paintGroup)
        {
            if (ModelState.IsValid)
            {
                paintGroup.PaintGroupId = Guid.NewGuid();
                _context.Add(paintGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paintGroup);
        }

        // GET: PaintGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.PaintGroup == null)
            {
                return NotFound();
            }

            var paintGroup = await _context.PaintGroup.FindAsync(id);
            if (paintGroup == null)
            {
                return NotFound();
            }
            return View(paintGroup);
        }

        // POST: PaintGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PaintGroupId,ManufacturerId,PaintGroupName,PaintGroupDescription")] PaintGroup paintGroup)
        {
            if (id != paintGroup.PaintGroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paintGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaintGroupExists(paintGroup.PaintGroupId))
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
            return View(paintGroup);
        }

        // GET: PaintGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.PaintGroup == null)
            {
                return NotFound();
            }

            var paintGroup = await _context.PaintGroup
                .FirstOrDefaultAsync(m => m.PaintGroupId == id);
            if (paintGroup == null)
            {
                return NotFound();
            }

            return View(paintGroup);
        }

        // POST: PaintGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.PaintGroup == null)
            {
                return Problem("Entity set 'PaintContext.PaintGroup'  is null.");
            }
            var paintGroup = await _context.PaintGroup.FindAsync(id);
            if (paintGroup != null)
            {
                _context.PaintGroup.Remove(paintGroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaintGroupExists(Guid id)
        {
          return (_context.PaintGroup?.Any(e => e.PaintGroupId == id)).GetValueOrDefault();
        }
    }
}
