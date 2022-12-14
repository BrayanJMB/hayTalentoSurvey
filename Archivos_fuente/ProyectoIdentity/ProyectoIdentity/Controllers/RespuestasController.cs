using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models.ModelsJourney;
using ProyectoIdentity.Models.ModelTemplateJorney;

namespace ProyectoIdentity.Controllers
{
    public class RespuestasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RespuestasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Respuestas
        public async Task<IActionResult> Index()
        {
            
            var appDbContext = _context.Respuesta.Include(r => r.Pregunta).Include(r => r.Respondente);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Respuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Respuesta == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuesta
                .Include(r => r.Pregunta)
                .Include(r => r.Respondente)
                .FirstOrDefaultAsync(m => m.PreguntaId == id);
            if (respuesta == null)
            {
                return NotFound();
            }

            return View(respuesta);
        }

        // GET: Respuestas/Create
        public IActionResult Create()
        {
            ViewData["PreguntaId"] = new SelectList(_context.Pregunta, "Id", "Id");
            ViewData["RespondenteId"] = new SelectList(_context.Respondente, "Id", "Id");
            return View();
        }

        // POST: Respuestas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescripcionRespuesta,RespondenteId,PreguntaId")] Respuesta respuesta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(respuesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PreguntaId"] = new SelectList(_context.Pregunta, "Id", "Id", respuesta.PreguntaId);
            ViewData["RespondenteId"] = new SelectList(_context.Respondente, "Id", "Id", respuesta.RespondenteId);
            return View(respuesta);
        }

        // GET: Respuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Respuesta == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuesta.FindAsync(id);
            if (respuesta == null)
            {
                return NotFound();
            }
            ViewData["PreguntaId"] = new SelectList(_context.Pregunta, "Id", "Id", respuesta.PreguntaId);
            ViewData["RespondenteId"] = new SelectList(_context.Respondente, "Id", "Id", respuesta.RespondenteId);
            return View(respuesta);
        }

        // POST: Respuestas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DescripcionRespuesta,RespondenteId,PreguntaId")] Respuesta respuesta)
        {
            if (id != respuesta.PreguntaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespuestaExists(respuesta.PreguntaId))
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
            ViewData["PreguntaId"] = new SelectList(_context.Pregunta, "Id", "Id", respuesta.PreguntaId);
            ViewData["RespondenteId"] = new SelectList(_context.Respondente, "Id", "Id", respuesta.RespondenteId);
            return View(respuesta);
        }

        // GET: Respuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Respuesta == null)
            {
                return NotFound();
            }

            var respuesta = await _context.Respuesta
                .Include(r => r.Pregunta)
                .Include(r => r.Respondente)
                .FirstOrDefaultAsync(m => m.PreguntaId == id);
            if (respuesta == null)
            {
                return NotFound();
            }

            return View(respuesta);
        }

        // POST: Respuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Respuesta == null)
            {
                return Problem("Entity set 'AppDbContext.Respuesta'  is null.");
            }
            var respuesta = await _context.Respuesta.FindAsync(id);
            if (respuesta != null)
            {
                _context.Respuesta.Remove(respuesta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespuestaExists(int id)
        {
          return _context.Respuesta.Any(e => e.PreguntaId == id);
        }

        public async Task<IActionResult> IndexRespuestas()
        {
            ViewBag.Message = "Login";
            var Model = new ModelSurvey();
            Model.Categorias = ModelSurvey.Categories();
            return View(Model);
        }

        public async Task<IActionResult> RedirectIndexRespuestas()
        {
            ViewBag.Message = "EnvioRedirectRespuestas";
            return View();
        }

        public async Task<IActionResult> EnvioIndexRespuestas()
        {
            ViewBag.Message = "Login";
            return View();
        }


        ////////////Encuesta Madurez//////////////////////////

        public async Task<IActionResult> IndexRespuestasMadurez()
        {
            ViewBag.Message = "Login";
            var Model = new ModelSurvey();
            Model.Categorias = ModelSurvey.CategoriesMadurez();
            return View(Model);
        }

        public async Task<IActionResult> RedirectIndexRespuestasMadurez()
        {
            ViewBag.Message = "EnvioRedirectRespuestasMadurez";
            return View();
        }

        public async Task<IActionResult> EnvioIndexRespuestasMadurez()
        {
            ViewBag.Message = "Login";
            return View();
        }
    }
}
