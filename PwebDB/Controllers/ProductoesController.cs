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
    public class ProductoesController : Controller
    {
        private readonly PerfimeDatabaseContext _context;

        public ProductoesController(PerfimeDatabaseContext context)
        {
            _context = context;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            var perfimeDatabaseContext = _context.Productos.Include(p => p.IdCategoriaNavigation).Include(p => p.IdMarcaPerfumeNavigation).Include(p => p.IdTipoPerfumeNavigation);
            return View(await perfimeDatabaseContext.ToListAsync());
        }

        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdCategoriaNavigation)
                .Include(p => p.IdMarcaPerfumeNavigation)
                .Include(p => p.IdTipoPerfumeNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria");
            ViewData["IdMarcaPerfume"] = new SelectList(_context.MarcaPerfumes, "IdMarcaPerfume", "IdMarcaPerfume");
            ViewData["IdTipoPerfume"] = new SelectList(_context.TipoPerfumes, "IdTipoPerfume", "IdTipoPerfume");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,Nombre,IdMarcaPerfume,IdCategoria,Descripcion,Precio,VolumenEnMl,Stock,Imagen,FechaAgregado,IdTipoPerfume")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", producto.IdCategoria);
            ViewData["IdMarcaPerfume"] = new SelectList(_context.MarcaPerfumes, "IdMarcaPerfume", "IdMarcaPerfume", producto.IdMarcaPerfume);
            ViewData["IdTipoPerfume"] = new SelectList(_context.TipoPerfumes, "IdTipoPerfume", "IdTipoPerfume", producto.IdTipoPerfume);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", producto.IdCategoria);
            ViewData["IdMarcaPerfume"] = new SelectList(_context.MarcaPerfumes, "IdMarcaPerfume", "IdMarcaPerfume", producto.IdMarcaPerfume);
            ViewData["IdTipoPerfume"] = new SelectList(_context.TipoPerfumes, "IdTipoPerfume", "IdTipoPerfume", producto.IdTipoPerfume);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,Nombre,IdMarcaPerfume,IdCategoria,Descripcion,Precio,VolumenEnMl,Stock,Imagen,FechaAgregado,IdTipoPerfume")] Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.IdProducto))
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
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", producto.IdCategoria);
            ViewData["IdMarcaPerfume"] = new SelectList(_context.MarcaPerfumes, "IdMarcaPerfume", "IdMarcaPerfume", producto.IdMarcaPerfume);
            ViewData["IdTipoPerfume"] = new SelectList(_context.TipoPerfumes, "IdTipoPerfume", "IdTipoPerfume", producto.IdTipoPerfume);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdCategoriaNavigation)
                .Include(p => p.IdMarcaPerfumeNavigation)
                .Include(p => p.IdTipoPerfumeNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.IdProducto == id);
        }
    }
}
