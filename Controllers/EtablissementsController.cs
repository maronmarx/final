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
    public class EtablissementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtablissementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Etablissements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.etablissements.Include(e => e.formation).Include(e => e.ville);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Etablissements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.etablissements == null)
            {
                return NotFound();
            }

            var etablissement = await _context.etablissements
                .Include(e => e.formation)
                .Include(e => e.ville)
                .FirstOrDefaultAsync(m => m.etabId == id);
            if (etablissement == null)
            {
                return NotFound();
            }

            return View(etablissement);
        }

        // GET: Etablissements/Create
        public IActionResult Create()
        {
            ViewData["id_formation"] = new SelectList(_context.formations, "id_formation", "id_formation");
            ViewData["id_ville"] = new SelectList(_context.villes, "id_ville", "id_ville");
            return View();
        }

        // POST: Etablissements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("etabId,nom,Description,Image,id_formation,id_filier,niveau,id_ville")] Etablissement etablissement)
        {
            Upload(etablissement);
            if (ModelState.IsValid)
            {
                _context.Add(etablissement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_formation"] = new SelectList(_context.formations, "id_formation", "id_formation", etablissement.id_formation);
            ViewData["id_ville"] = new SelectList(_context.villes, "id_ville", "id_ville", etablissement.id_ville);
            return View(etablissement);
        }

        // GET: Etablissements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.etablissements == null)
            {
                return NotFound();
            }

            var etablissement = await _context.etablissements.FindAsync(id);
            if (etablissement == null)
            {
                return NotFound();
            }
            ViewData["id_formation"] = new SelectList(_context.formations, "id_formation", "id_formation", etablissement.id_formation);
            ViewData["id_ville"] = new SelectList(_context.villes, "id_ville", "id_ville", etablissement.id_ville);
            return View(etablissement);
        }

        // POST: Etablissements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("etabId,nom,Description,Image,id_formation,id_filier,niveau,id_ville")] Etablissement etablissement)
        {
            if (id != etablissement.etabId)
            {
                return NotFound();
            }

            Upload(etablissement);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etablissement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtablissementExists(etablissement.etabId))
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
            ViewData["id_formation"] = new SelectList(_context.formations, "id_formation", "id_formation", etablissement.id_formation);
            ViewData["id_ville"] = new SelectList(_context.villes, "id_ville", "id_ville", etablissement.id_ville);
            return View(etablissement);
        }

        // GET: Etablissements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.etablissements == null)
            {
                return NotFound();
            }

            var etablissement = await _context.etablissements
                .Include(e => e.formation)
                .Include(e => e.ville)
                .FirstOrDefaultAsync(m => m.etabId == id);
            if (etablissement == null)
            {
                return NotFound();
            }

            return View(etablissement);
        }

        // POST: Etablissements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.etablissements == null)
            {
                return Problem("Entity set 'ApplicationDbContext.etablissements'  is null.");
            }
            var etablissement = await _context.etablissements.FindAsync(id);
            if (etablissement != null)
            {
                _context.etablissements.Remove(etablissement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtablissementExists(int? id)
        {
          return _context.etablissements.Any(e => e.etabId == id);
        }
        private void Upload(Etablissement etablissement)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count() > 0)
            {
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var fileStream = new FileStream(Path.Combine(@"wwwroot/", "images", ImageName), FileMode.Create);
                file[0].CopyTo(fileStream);
                etablissement.Image = ImageName;
            }
            else if (etablissement.Image == null && etablissement.etabId == null)
            {
                etablissement.Image = "DefaultImage.png";
            }
            else
            {
                etablissement.Image = etablissement.Image;
            }
        }
    }
}
