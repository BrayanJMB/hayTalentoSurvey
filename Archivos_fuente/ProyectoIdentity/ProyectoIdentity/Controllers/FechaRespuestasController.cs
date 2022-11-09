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
    public class FechaRespuestasController : Controller
    {
        private readonly AppDbContext _context;

        public FechaRespuestasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FechaRespuestas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.FechaRespuesta.Include(f => f.Respondente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: FechaRespuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FechaRespuesta == null)
            {
                return NotFound();
            }

            var fechaRespuesta = await _context.FechaRespuesta
                .Include(f => f.Respondente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fechaRespuesta == null)
            {
                return NotFound();
            }

            return View(fechaRespuesta);
        }

        // GET: FechaRespuestas/Create
        public IActionResult Create()
        {
            ViewData["RespondenteId"] = new SelectList(_context.Respondente, "Id", "Id");
            return View();
        }

        // POST: FechaRespuestas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaDeRespuesta,RespondenteId")] FechaRespuesta fechaRespuesta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fechaRespuesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RespondenteId"] = new SelectList(_context.Respondente, "Id", "Id", fechaRespuesta.RespondenteId);
            return View(fechaRespuesta);
        }

        // GET: FechaRespuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FechaRespuesta == null)
            {
                return NotFound();
            }

            var fechaRespuesta = await _context.FechaRespuesta.FindAsync(id);
            if (fechaRespuesta == null)
            {
                return NotFound();
            }
            ViewData["RespondenteId"] = new SelectList(_context.Respondente, "Id", "Id", fechaRespuesta.RespondenteId);
            return View(fechaRespuesta);
        }

        // POST: FechaRespuestas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaDeRespuesta,RespondenteId")] FechaRespuesta fechaRespuesta)
        {
            if (id != fechaRespuesta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fechaRespuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FechaRespuestaExists(fechaRespuesta.Id))
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
            ViewData["RespondenteId"] = new SelectList(_context.Respondente, "Id", "Id", fechaRespuesta.RespondenteId);
            return View(fechaRespuesta);
        }

        // GET: FechaRespuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FechaRespuesta == null)
            {
                return NotFound();
            }

            var fechaRespuesta = await _context.FechaRespuesta
                .Include(f => f.Respondente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fechaRespuesta == null)
            {
                return NotFound();
            }

            return View(fechaRespuesta);
        }

        // POST: FechaRespuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FechaRespuesta == null)
            {
                return Problem("Entity set 'AppDbContext.FechaRespuesta'  is null.");
            }
            var fechaRespuesta = await _context.FechaRespuesta.FindAsync(id);
            if (fechaRespuesta != null)
            {
                _context.FechaRespuesta.Remove(fechaRespuesta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FechaRespuestaExists(int id)
        {
          return _context.FechaRespuesta.Any(e => e.Id == id);
        }
    }
}
