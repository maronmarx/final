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
            var applicationDbContext = _context.etablissements.Include(f => f.Formation).OrderBy(f => f.nom);
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
                .Include(f => f.Formation).OrderBy(f => f.nom)
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
            ViewBag.formations = _context.formations.OrderBy(f => f.nom_FormationId).ToList();
            return View();
        }

        // POST: Etablissements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Etablissement etablissement)
        {
            Upload(etablissement);
            if (ModelState.IsValid)
            {
                _context.etablissements.Add(etablissement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.formations = _context.formations.OrderBy(f => f.nom_FormationId).ToListAsync();
            return View(etablissement);
        }

        // GET: Etablissements/Edit/5
        public IActionResult Edit(int? id)
        {
            

            ViewBag.formations = _context.formations.OrderBy(f => f.nom_FormationId).ToList();
            var etablissement = _context.etablissements.Find(id);
            return View(etablissement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Etablissement etablissement)
        {
           
            Upload(etablissement);
            if (ModelState.IsValid)
            {
               
                _context.etablissements.Update(etablissement);
                _context.SaveChanges();   
                return RedirectToAction(nameof(Index));
            }

            ViewBag.formations = _context.formations.OrderBy(f => f.nom_FormationId).ToList();
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
                .Include(v => v.Formation)
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
