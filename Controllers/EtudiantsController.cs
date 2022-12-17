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
            var applicationDbContext = _context.etudiants.Include(e => e.Ville).OrderBy(e => e.niveau);
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
                .Include(e => e.Ville).OrderBy(e => e.niveau)
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
            ViewBag.villes = _context.villes.OrderBy(f => f.nom_ville).ToList();
            return View();
        }

        // POST: Etudiants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Etudiants etudiants)
        {
            if (ModelState.IsValid)
            {
                _context.etudiants.Add(etudiants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.villes = _context.villes.OrderBy(f => f.nom_ville).ToListAsync();
            return View(etudiants);
        }

        // GET: Etudiants/Edit/5
        public IActionResult Edit(int? id)
        {            
           
            
            ViewBag.villes = _context.villes.OrderBy(f => f.nom_ville).ToList();
            var etudiants = _context.etudiants.FindAsync(id);
            return View(etudiants);
        }

        // POST: Etudiants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Etudiants etudiants)
        {
            if (ModelState.IsValid)
            {
                
                    _context.etudiants.Update(etudiants);
                    _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            ViewBag.villes = _context.villes.OrderBy(f => f.nom_ville).ToList();
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
                .Include(e => e.Ville).OrderBy(e => e.niveau)
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
