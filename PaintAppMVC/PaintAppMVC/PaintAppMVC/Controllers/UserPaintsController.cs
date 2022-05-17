using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaintAppModels;

namespace PaintAppMVC.Controllers
{
    public class UserPaintsController : Controller
    {
        private readonly PaintContext _context;

        public UserPaintsController(PaintContext context)
        {
            _context = context;
        }

        // GET: UserPaints
        public async Task<IActionResult> Index()
        {
            //Filter by currently logged in user
            Guid userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return _context.UserPaint.Where(up => up.UserId == userId) != null ? 
                          View(await _context.UserPaint.Where(up => up.UserId == userId).ToListAsync()) :
                          Problem("Entity set 'PaintContext.UserPaint'  is null.");
        }

        // GET: UserPaints/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.UserPaint == null)
            {
                return NotFound();
            }

            var userPaint = await _context.UserPaint
                .FirstOrDefaultAsync(m => m.UserPaintId == id);
            if (userPaint == null)
            {
                return NotFound();
            }

            return View(userPaint);
        }

        // GET: UserPaints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserPaints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserPaintId,UserId,PaintId,DateCreated")] UserPaint userPaint)
        {
            if (ModelState.IsValid)
            {
                userPaint.UserPaintId = Guid.NewGuid();
                _context.Add(userPaint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userPaint);
        }

        // GET: UserPaints/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.UserPaint == null)
            {
                return NotFound();
            }

            var userPaint = await _context.UserPaint.FindAsync(id);
            if (userPaint == null)
            {
                return NotFound();
            }
            return View(userPaint);
        }

        // POST: UserPaints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UserPaintId,UserId,PaintId,DateCreated")] UserPaint userPaint)
        {
            if (id != userPaint.UserPaintId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPaint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPaintExists(userPaint.UserPaintId))
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
            return View(userPaint);
        }

        // GET: UserPaints/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.UserPaint == null)
            {
                return NotFound();
            }

            var userPaint = await _context.UserPaint
                .FirstOrDefaultAsync(m => m.UserPaintId == id);
            if (userPaint == null)
            {
                return NotFound();
            }

            return View(userPaint);
        }

        // POST: UserPaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.UserPaint == null)
            {
                return Problem("Entity set 'PaintContext.UserPaint'  is null.");
            }
            var userPaint = await _context.UserPaint.FindAsync(id);
            if (userPaint != null)
            {
                _context.UserPaint.Remove(userPaint);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPaintExists(Guid id)
        {
          return (_context.UserPaint?.Any(e => e.UserPaintId == id)).GetValueOrDefault();
        }
    }
}
