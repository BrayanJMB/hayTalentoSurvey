
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models.ModelsJourney;

namespace ProyectoIdentity.Controllers
{
    public class EncuestasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Dictionary<string, string> preguntasBase = new();
        public EncuestasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Encuestas
        [Authorize]
        public async Task<IActionResult> Index()
        {

            var appDbContext = _context.Encuesta.Include(e => e.Company);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Index1()
        {
            var appDbContext = _context.Encuesta.Include(e => e.Company);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Encuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Encuesta == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuesta
                .Include(e => e.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encuesta == null)
            {
                return NotFound();
            }

            return View(encuesta);
        }

        // GET: Encuestas/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId");
            return View();
        }

        // POST: Encuestas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreEncuesta,DescripcionEncuesta,CompanyId")] Encuesta encuesta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encuesta);
                await _context.SaveChangesAsync();
                

                //agregar las Categorias

                //agregar las preguntas

                //Agregar Opciones Existentes

                //Modificar las preguntas
                //Listado de preguntas una por una
                //Retornar vistas de preguntas donde el id de la encuasta sea el creado anterioremente
                return RedirectToAction(nameof(Index1));
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", encuesta.CompanyId);
            return View(encuesta);
        }

        // GET: Encuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Encuesta == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuesta.FindAsync(id);
            if (encuesta == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", encuesta.CompanyId);
            return View(encuesta);
        }

        // POST: Encuestas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreEncuesta,DescripcionEncuesta,CompanyId")] Encuesta encuesta)
        {
            if (id != encuesta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncuestaExists(encuesta.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", encuesta.CompanyId);
            return View(encuesta);
        }

        // GET: Encuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Encuesta == null)
            {
                return NotFound();
            }

            var encuesta = await _context.Encuesta
                .Include(e => e.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (encuesta == null)
            {
                return NotFound();
            }

            return View(encuesta);
        }

        // POST: Encuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //las encuestas no se pueden borrar solo inactivar parta que nboi se puedan observar
            if (_context.Encuesta == null)
            {
                return Problem("Entity set 'AppDbContext.Encuesta'  is null.");
            }
            var encuesta = await _context.Encuesta.FindAsync(id);
            if (encuesta != null)
            {
                _context.Encuesta.Remove(encuesta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncuestaExists(int id)
        {
          return _context.Encuesta.Any(e => e.Id == id);
        }
    }
}
