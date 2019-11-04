using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Web.Data;
using Xamarin.Web.Data.Entities;

namespace Xamarin.Web.Controllers
{
    public class CareersController : Controller
    {
        private readonly DataContext _context;

        public CareersController(DataContext context)
        {
            _context = context;
        }

        // GET: Careers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Careers.ToListAsync());
        }

        // GET: Careers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Careers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (career == null)
            {
                return NotFound();
            }

            return View(career);
        }

        // GET: Careers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Careers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Career career)
        {
            if (ModelState.IsValid)
            {
                _context.Add(career);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(career);
        }

        // GET: Careers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Careers.FindAsync(id);
            if (career == null)
            {
                return NotFound();
            }
            return View(career);
        }

        // POST: Careers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Career career)
        {
            if (id != career.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(career);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareerExists(career.Id))
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
            return View(career);
        }

        // GET: Careers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var career = await _context.Careers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (career == null)
            {
                return NotFound();
            }

            return View(career);
        }

        // POST: Careers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var career = await _context.Careers.FindAsync(id);
            _context.Careers.Remove(career);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareerExists(int id)
        {
            return _context.Careers.Any(e => e.Id == id);
        }
    }
}
