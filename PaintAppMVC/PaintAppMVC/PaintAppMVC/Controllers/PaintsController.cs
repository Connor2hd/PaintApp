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
            //var pgData = _context.PaintGroup.AsQueryable();
            foreach(Paint p in _context.Paint)
            {
                //Retrieves the paint group name as the paints table only contains the group ip
                p.PaintGroupName = _context.PaintGroup.Where(pg => pg.PaintGroupId == p.GroupId).FirstOrDefault().PaintGroupName.ToString();
                //Retrieves a bool value that is true if the paint exists in the users collection (UserPaint table)
                p.InCollection = _context.UserPaint.Where(up => up.UserId == new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))).Where(up => up.PaintId == p.PaintId).FirstOrDefault() != null;
            }

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

            paint.PaintGroupName = _context.PaintGroup.Where(pg => pg.PaintGroupId == paint.GroupId).FirstOrDefault().PaintGroupName.ToString();

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

        [HttpPost, ActionName("Save")]
        public async Task<IActionResult> Save(string[] collectionIds, string[] groupIds)
        {
            //Currently a single save action will only deal with 1 paint group at a time
            Guid paintGroupId = new Guid(groupIds[0]);
            Guid userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            //Remove all paints from the current paint group and user
            _context.UserPaint.RemoveRange(_context.UserPaint.Where(x => x.GroupId == paintGroupId).Where(x => x.UserId == userId));

            //Add paints that match the checked IDs
            foreach(string item in collectionIds)
            {
                UserPaint newPaint = new UserPaint();
                newPaint.GroupId = paintGroupId;
                newPaint.UserId = userId;
                newPaint.PaintId = new Guid(item);
                newPaint.DateCreated = DateTime.Now;
                _context.UserPaint.Add(newPaint);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
