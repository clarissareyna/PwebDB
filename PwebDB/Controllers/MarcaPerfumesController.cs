using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PwebDB.Models.dbModels;

namespace PwebDB.Controllers
{
    public class MarcaPerfumesController : Controller
    {
        private readonly PerfimeDatabaseContext _context;

        public MarcaPerfumesController(PerfimeDatabaseContext context)
        {
            _context = context;
        }

        // GET: MarcaPerfumes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MarcaPerfumes.ToListAsync());
        }

        // GET: MarcaPerfumes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaPerfume = await _context.MarcaPerfumes
                .FirstOrDefaultAsync(m => m.IdMarcaPerfume == id);
            if (marcaPerfume == null)
            {
                return NotFound();
            }

            return View(marcaPerfume);
        }

        // GET: MarcaPerfumes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarcaPerfumes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMarcaPerfume,Marca")] MarcaPerfume marcaPerfume)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcaPerfume);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaPerfume);
        }

        // GET: MarcaPerfumes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaPerfume = await _context.MarcaPerfumes.FindAsync(id);
            if (marcaPerfume == null)
            {
                return NotFound();
            }
            return View(marcaPerfume);
        }

        // POST: MarcaPerfumes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMarcaPerfume,Marca")] MarcaPerfume marcaPerfume)
        {
            if (id != marcaPerfume.IdMarcaPerfume)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcaPerfume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaPerfumeExists(marcaPerfume.IdMarcaPerfume))
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
            return View(marcaPerfume);
        }

        // GET: MarcaPerfumes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcaPerfume = await _context.MarcaPerfumes
                .FirstOrDefaultAsync(m => m.IdMarcaPerfume == id);
            if (marcaPerfume == null)
            {
                return NotFound();
            }

            return View(marcaPerfume);
        }

        // POST: MarcaPerfumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marcaPerfume = await _context.MarcaPerfumes.FindAsync(id);
            if (marcaPerfume != null)
            {
                _context.MarcaPerfumes.Remove(marcaPerfume);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaPerfumeExists(int id)
        {
            return _context.MarcaPerfumes.Any(e => e.IdMarcaPerfume == id);
        }
    }
}
