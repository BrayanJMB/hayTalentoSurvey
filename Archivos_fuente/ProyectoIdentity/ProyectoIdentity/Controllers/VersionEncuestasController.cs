using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiPrueba.ConText;
using ApiPrueba.Models.ModelsJourney;

namespace ApiPrueba.Controllers
{
    public class VersionEncuestasController : Controller
    {
        private readonly AppDbContext _context;

        public VersionEncuestasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: VersionEncuestas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.VersionEncuesta.Include(v => v.Encuesta);
            return View(await appDbContext.ToListAsync());
        }

        // GET: VersionEncuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VersionEncuesta == null)
            {
                return NotFound();
            }

            var versionEncuesta = await _context.VersionEncuesta
                .Include(v => v.Encuesta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (versionEncuesta == null)
            {
                return NotFound();
            }

            return View(versionEncuesta);
        }

        // GET: VersionEncuestas/Create
        public IActionResult Create()
        {
            ViewData["EncuestaId"] = new SelectList(_context.Encuesta, "Id", "Id");
            return View();
        }

        // POST: VersionEncuestas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VersionNumber,FechaMaximoPlazo,FechaCreacion,EncuestaId")] VersionEncuesta versionEncuesta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(versionEncuesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EncuestaId"] = new SelectList(_context.Encuesta, "Id", "Id", versionEncuesta.EncuestaId);
            return View(versionEncuesta);
        }

        // GET: VersionEncuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VersionEncuesta == null)
            {
                return NotFound();
            }

            var versionEncuesta = await _context.VersionEncuesta.FindAsync(id);
            if (versionEncuesta == null)
            {
                return NotFound();
            }
            ViewData["EncuestaId"] = new SelectList(_context.Encuesta, "Id", "Id", versionEncuesta.EncuestaId);
            return View(versionEncuesta);
        }

        // POST: VersionEncuestas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VersionNumber,FechaMaximoPlazo,FechaCreacion,EncuestaId")] VersionEncuesta versionEncuesta)
        {
            if (id != versionEncuesta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(versionEncuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VersionEncuestaExists(versionEncuesta.Id))
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
            ViewData["EncuestaId"] = new SelectList(_context.Encuesta, "Id", "Id", versionEncuesta.EncuestaId);
            return View(versionEncuesta);
        }

        // GET: VersionEncuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VersionEncuesta == null)
            {
                return NotFound();
            }

            var versionEncuesta = await _context.VersionEncuesta
                .Include(v => v.Encuesta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (versionEncuesta == null)
            {
                return NotFound();
            }

            return View(versionEncuesta);
        }

        // POST: VersionEncuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VersionEncuesta == null)
            {
                return Problem("Entity set 'AppDbContext.VersionEncuesta'  is null.");
            }
            var versionEncuesta = await _context.VersionEncuesta.FindAsync(id);
            if (versionEncuesta != null)
            {
                _context.VersionEncuesta.Remove(versionEncuesta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VersionEncuestaExists(int id)
        {
          return _context.VersionEncuesta.Any(e => e.Id == id);
        }
    }
}
