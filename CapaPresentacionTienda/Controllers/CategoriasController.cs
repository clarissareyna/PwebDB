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
    public class CategoriasController : Controller
    {
        private readonly PerfimeDatabaseContext _context;

        public CategoriasController(PerfimeDatabaseContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            var perfimeDatabaseContext = _context.Categoria.Include(c => c.CategoriaPadreNavigation);
            return View(await perfimeDatabaseContext.ToListAsync());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorium = await _context.Categoria
                .Include(c => c.CategoriaPadreNavigation)
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categorium == null)
            {
                return NotFound();
            }

            return View(categorium);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            ViewData["CategoriaPadre"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria");
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoria,Descripcion,CategoriaPadre")] Categorium categorium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaPadre"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", categorium.CategoriaPadre);
            return View(categorium);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorium = await _context.Categoria.FindAsync(id);
            if (categorium == null)
            {
                return NotFound();
            }
            ViewData["CategoriaPadre"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", categorium.CategoriaPadre);
            return View(categorium);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria,Descripcion,CategoriaPadre")] Categorium categorium)
        {
            if (id != categorium.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriumExists(categorium.IdCategoria))
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
            ViewData["CategoriaPadre"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", categorium.CategoriaPadre);
            return View(categorium);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorium = await _context.Categoria
                .Include(c => c.CategoriaPadreNavigation)
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categorium == null)
            {
                return NotFound();
            }

            return View(categorium);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorium = await _context.Categoria.FindAsync(id);
            if (categorium != null)
            {
                _context.Categoria.Remove(categorium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriumExists(int id)
        {
            return _context.Categoria.Any(e => e.IdCategoria == id);
        }
    }
}
