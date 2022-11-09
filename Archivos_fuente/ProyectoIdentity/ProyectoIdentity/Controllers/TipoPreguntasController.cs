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
    public class TipoPreguntasController : Controller
    {
        private readonly AppDbContext _context;

        public TipoPreguntasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoPreguntas
        public async Task<IActionResult> Index()
        {
              return View(await _context.TipoPregunta.ToListAsync());
        }

        // GET: TipoPreguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoPregunta == null)
            {
                return NotFound();
            }

            var tipoPregunta = await _context.TipoPregunta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPregunta == null)
            {
                return NotFound();
            }

            return View(tipoPregunta);
        }

        // GET: TipoPreguntas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPreguntas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreTipoPregunta,Descripcion")] TipoPregunta tipoPregunta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPregunta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPregunta);
        }

        // GET: TipoPreguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoPregunta == null)
            {
                return NotFound();
            }

            var tipoPregunta = await _context.TipoPregunta.FindAsync(id);
            if (tipoPregunta == null)
            {
                return NotFound();
            }
            return View(tipoPregunta);
        }

        // POST: TipoPreguntas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreTipoPregunta,Descripcion")] TipoPregunta tipoPregunta)
        {
            if (id != tipoPregunta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPregunta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPreguntaExists(tipoPregunta.Id))
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
            return View(tipoPregunta);
        }

        // GET: TipoPreguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoPregunta == null)
            {
                return NotFound();
            }

            var tipoPregunta = await _context.TipoPregunta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPregunta == null)
            {
                return NotFound();
            }

            return View(tipoPregunta);
        }

        // POST: TipoPreguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoPregunta == null)
            {
                return Problem("Entity set 'AppDbContext.TipoPregunta'  is null.");
            }
            var tipoPregunta = await _context.TipoPregunta.FindAsync(id);
            if (tipoPregunta != null)
            {
                _context.TipoPregunta.Remove(tipoPregunta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPreguntaExists(int id)
        {
          return _context.TipoPregunta.Any(e => e.Id == id);
        }
    }
}
