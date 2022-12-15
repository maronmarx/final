using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalOr.Data;
using FinalOr.Models;

namespace FinalOr.Controllers
{
    public class EtudiantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtudiantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Etudiants
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.etudiants.Include(e => e.filiere).Include(e => e.ville);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Etudiants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.etudiants == null)
            {
                return NotFound();
            }

            var etudiants = await _context.etudiants
                .Include(e => e.filiere)
                .Include(e => e.ville)
                .FirstOrDefaultAsync(m => m.etudiantId == id);
            if (etudiants == null)
            {
                return NotFound();
            }

            return View(etudiants);
        }

        // GET: Etudiants/Create
        public IActionResult Create()
        {
            ViewData["id_filier"] = new SelectList(_context.filieres, "id_filier", "nom_Filier");
            ViewData["id_ville"] = new SelectList(_context.villes, "id_ville", "id_ville");
            return View();
        }

        // POST: Etudiants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("etudiantId,niveau,id_filier,id_ville")] Etudiants etudiants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etudiants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_filier"] = new SelectList(_context.filieres, "id_filier", "nom_Filier", etudiants.id_filier);
            ViewData["id_ville"] = new SelectList(_context.villes, "id_ville", "id_ville", etudiants.id_ville);
            return View(etudiants);
        }

        // GET: Etudiants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.etudiants == null)
            {
                return NotFound();
            }

            var etudiants = await _context.etudiants.FindAsync(id);
            if (etudiants == null)
            {
                return NotFound();
            }
            ViewData["id_filier"] = new SelectList(_context.filieres, "id_filier", "nom_Filier", etudiants.id_filier);
            ViewData["id_ville"] = new SelectList(_context.villes, "id_ville", "id_ville", etudiants.id_ville);
            return View(etudiants);
        }

        // POST: Etudiants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("etudiantId,niveau,id_filier,id_ville")] Etudiants etudiants)
        {
            if (id != etudiants.etudiantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etudiants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtudiantsExists(etudiants.etudiantId))
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
            ViewData["id_filier"] = new SelectList(_context.filieres, "id_filier", "nom_Filier", etudiants.id_filier);
            ViewData["id_ville"] = new SelectList(_context.villes, "id_ville", "id_ville", etudiants.id_ville);
            return View(etudiants);
        }

        // GET: Etudiants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.etudiants == null)
            {
                return NotFound();
            }

            var etudiants = await _context.etudiants
                .Include(e => e.filiere)
                .Include(e => e.ville)
                .FirstOrDefaultAsync(m => m.etudiantId == id);
            if (etudiants == null)
            {
                return NotFound();
            }

            return View(etudiants);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.etudiants == null)
            {
                return Problem("Entity set 'ApplicationDbContext.etudiants'  is null.");
            }
            var etudiants = await _context.etudiants.FindAsync(id);
            if (etudiants != null)
            {
                _context.etudiants.Remove(etudiants);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtudiantsExists(int? id)
        {
          return _context.etudiants.Any(e => e.etudiantId == id);
        }
    }
}
