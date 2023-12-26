using BinaryCoffeeShop.Data;
using BinaryCoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BinaryCoffeeShop.Controllers
{
    public class DirectionsController : Controller
    {
        private readonly BinaryCoffeeShopDbContext _context;

        public DirectionsController(BinaryCoffeeShopDbContext context)
        {
            _context = context;
        }

        // GET: Directions
        public async Task<IActionResult> Index()
        {
            var binaryCoffeeShopDbContext = _context.Directions.Include(d => d.User);
            return View(await binaryCoffeeShopDbContext.ToListAsync());
        }

        // GET: Directions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direction = await _context.Directions
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DirectionId == id);
            if (direction == null)
            {
                return NotFound();
            }

            return View(direction);
        }

        // GET: Directions/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UsertId", "Address");
            return View();
        }

        // POST: Directions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectionId,Address,City,State,ZipCode,UserId")] Direction direction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UsertId", "Address", direction.UserId);
            return View(direction);
        }

        // GET: Directions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direction = await _context.Directions.FindAsync(id);
            if (direction == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UsertId", "Address", direction.UserId);
            return View(direction);
        }

        // POST: Directions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DirectionId,Address,City,State,ZipCode,UserId")] Direction direction)
        {
            if (id != direction.DirectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectionExists(direction.DirectionId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UsertId", "Address", direction.UserId);
            return View(direction);
        }

        // GET: Directions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direction = await _context.Directions
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DirectionId == id);
            if (direction == null)
            {
                return NotFound();
            }

            return View(direction);
        }

        // POST: Directions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direction = await _context.Directions.FindAsync(id);
            if (direction != null)
            {
                _context.Directions.Remove(direction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectionExists(int id)
        {
            return _context.Directions.Any(e => e.DirectionId == id);
        }
    }
}
