using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models.ModelsJourney;

namespace ProyectoIdentity.Controllers
{
    public class OpcionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpcionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Opcions
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Opcion.Include(o => o.Pregunta);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Opcions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Opcion == null)
            {
                return NotFound();
            }

            var opcion = await _context.Opcion
                .Include(o => o.Pregunta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opcion == null)
            {
                return NotFound();
            }

            return View(opcion);
        }

        // GET: Opcions/Create
        public IActionResult Create()
        {
            ViewData["PreguntaId"] = new SelectList(_context.Pregunta, "Id", "Id");
            return View();
        }

        // POST: Opcions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,NumeroOpcion,PreguntaId")] Opcion opcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PreguntaId"] = new SelectList(_context.Pregunta, "Id", "Id", opcion.PreguntaId);
            return View(opcion);
        }

        // GET: Opcions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Opcion == null)
            {
                return NotFound();
            }

            var opcion = await _context.Opcion.FindAsync(id);
            if (opcion == null)
            {
                return NotFound();
            }
            ViewData["PreguntaId"] = new SelectList(_context.Pregunta, "Id", "Id", opcion.PreguntaId);
            return View(opcion);
        }

        // POST: Opcions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,NumeroOpcion,PreguntaId")] Opcion opcion)
        {
            if (id != opcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpcionExists(opcion.Id))
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
            ViewData["PreguntaId"] = new SelectList(_context.Pregunta, "Id", "Id", opcion.PreguntaId);
            return View(opcion);
        }

        // GET: Opcions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Opcion == null)
            {
                return NotFound();
            }

            var opcion = await _context.Opcion
                .Include(o => o.Pregunta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opcion == null)
            {
                return NotFound();
            }

            return View(opcion);
        }

        // POST: Opcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Opcion == null)
            {
                return Problem("Entity set 'AppDbContext.Opcion'  is null.");
            }
            var opcion = await _context.Opcion.FindAsync(id);
            if (opcion != null)
            {
                _context.Opcion.Remove(opcion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpcionExists(int id)
        {
          return _context.Opcion.Any(e => e.Id == id);
        }
    }
}
