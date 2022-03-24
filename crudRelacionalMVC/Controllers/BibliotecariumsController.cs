using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudRelacionalMVC.Models;

namespace crudRelacionalMVC.Controllers
{
    public class BibliotecariumsController : Controller
    {
        private readonly BibliotecasContext _context;

        public BibliotecariumsController(BibliotecasContext context)
        {
            _context = context;
        }

        // GET: Bibliotecariums
        public async Task<IActionResult> Index()
        {
            var bibliotecasContext = _context.Bibliotecaria.Include(b => b.IdBibliotecaNavigation);
            return View(await bibliotecasContext.ToListAsync());
        }

        // GET: Bibliotecariums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bibliotecarium = await _context.Bibliotecaria
                .Include(b => b.IdBibliotecaNavigation)
                .FirstOrDefaultAsync(m => m.IdBibliotecaria == id);
            if (bibliotecarium == null)
            {
                return NotFound();
            }

            return View(bibliotecarium);
        }

        // GET: Bibliotecariums/Create
        public IActionResult Create()
        {
            ViewData["IdBiblioteca"] = new SelectList(_context.Bibliotecas, "IdBiblioteca", "Nombre");
            return View();
        }

        // POST: Bibliotecariums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBibliotecaria,Nombre,Apellido,IdBiblioteca")] Bibliotecarium bibliotecarium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bibliotecarium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBiblioteca"] = new SelectList(_context.Bibliotecas, "IdBiblioteca", "Nombre", bibliotecarium.IdBiblioteca);
            return View(bibliotecarium);
        }

        // GET: Bibliotecariums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bibliotecarium = await _context.Bibliotecaria.FindAsync(id);
            if (bibliotecarium == null)
            {
                return NotFound();
            }
            ViewData["IdBiblioteca"] = new SelectList(_context.Bibliotecas, "IdBiblioteca", "Nombre", bibliotecarium.IdBiblioteca);
            return View(bibliotecarium);
        }

        // POST: Bibliotecariums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBibliotecaria,Nombre,Apellido,IdBiblioteca")] Bibliotecarium bibliotecarium)
        {
            if (id != bibliotecarium.IdBibliotecaria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bibliotecarium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BibliotecariumExists(bibliotecarium.IdBibliotecaria))
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
            ViewData["IdBiblioteca"] = new SelectList(_context.Bibliotecas, "IdBiblioteca", "Nombre", bibliotecarium.IdBiblioteca);
            return View(bibliotecarium);
        }

        // GET: Bibliotecariums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bibliotecarium = await _context.Bibliotecaria
                .Include(b => b.IdBibliotecaNavigation)
                .FirstOrDefaultAsync(m => m.IdBibliotecaria == id);
            if (bibliotecarium == null)
            {
                return NotFound();
            }

            return View(bibliotecarium);
        }

        // POST: Bibliotecariums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bibliotecarium = await _context.Bibliotecaria.FindAsync(id);
            _context.Bibliotecaria.Remove(bibliotecarium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BibliotecariumExists(int id)
        {
            return _context.Bibliotecaria.Any(e => e.IdBibliotecaria == id);
        }
    }
}
