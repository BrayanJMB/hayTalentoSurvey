using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models.ModelsJourney;

namespace ProyectoIdentity.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private SurveyShow _surveyShow;
        private string[] colores = { "bg-danger", "bg-danger", "bg-warning", "bg-info", "", "bg-success" };

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index(int surveyId)
        {
            var categorias = _context.EncuestaCategoria.Include(x => x.Categoria)
                .Include(x => x.Preguntas)
                .Where(x => x.EncuestaId == surveyId)
                .Select(x => x.Categoria).ToList();

            var respuestasPorCategoria = _context.Respuesta
                .Where(x => x.EncuestaRespondenteB.EncuestaId == surveyId)
                .Include(x => x.Pregunta)
                    .ThenInclude(x => x.EncuestaCategoria)
                        .ThenInclude(x => x.Categoria)
                .Select(x => new
                {
                    SurveyId=surveyId,
                    CategoriaId = x.Pregunta.EncuestaCategoria.CategoriaId,
                    CategoriaNombre = x.Pregunta.EncuestaCategoria.Categoria.NombreCategoria,
                    CategoriaDescripcion = x.Pregunta.EncuestaCategoria.Categoria.Descripcion,
                    PreguntaId = x.PreguntaId,
                    NumeroPregunta = x.Pregunta.NumeroPregunta,
                    TipoPreguntaID = x.Pregunta.TipoPreguntaId,
                    PreguntaNombre = x.Pregunta.NombrePregunta,
                    x.Valor,
                    x.DescripcionRespuesta,
                    x.Pregunta.TipoPreguntaId
                })
                .GroupBy(x => new { x.CategoriaId, x.CategoriaNombre, x.CategoriaDescripcion })
                .Select(g1 => new Categorias
                {
                    CategoriaId = g1.Key.CategoriaId,
                    CategoriaNombre = g1.Key.CategoriaNombre,
                    CategoriaDescripcion = g1.Key.CategoriaDescripcion,
                    surveyId = surveyId,
                    Preguntas = g1.GroupBy(x => new { x.PreguntaId, x.PreguntaNombre, x.TipoPreguntaId, x.NumeroPregunta })
                        .Select(g2 => new PreguntasBeneficios
                        {

                            PreguntaId = g2.Key.PreguntaId,
                            PreguntaNombre = g2.Key.PreguntaNombre,
                            TipoPreguntaId = g2.Key.TipoPreguntaId,
                            NumeroPregunta = g2.Key.NumeroPregunta,
                            Promedio = g2.Where(x => x.TipoPreguntaId == 2).Average(x => x.Valor) ?? 0,
                            porcentaje = ((int?)(g2.Where(x => x.TipoPreguntaId == 2).Average(x => x.Valor) * 20) ?? 0),
                            Respuestas = g2.Select(z => new RespuestasBeneficios
                            {
                                valor = z.Valor,
                                DescripcionRespuesta = z.DescripcionRespuesta
                            }).ToList(),
                            Color = colores[((int?)g2.Where(x => x.TipoPreguntaId == 2).Average(x => x.Valor)) ?? 0],
                            CantidadRespuestas = g2.Count()
                        }).ToList()
                }).ToList();

            return View(respuestasPorCategoria);
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FindAsync(id);
                
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            ViewData["EncuestaId"] = new SelectList(_context.Encuesta, "Id", "Id");
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCategoria,Descripcion,EncuestaId")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCategoria,Descripcion")] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.Id))
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
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria                
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categoria == null)
            {
                return Problem("Entity set 'AppDbContext.Categoria'  is null.");
            }
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria != null)
            {
                _context.Categoria.Remove(categoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
          return _context.Categoria.Any(e => e.Id == id);
        }

        [HttpPost]
        public JsonResult DatosDemograficos(int surveyId=1)
        {
            var respuestasPorCategoria = _context.Respuesta
                    .Where(x => x.EncuestaRespondenteB.EncuestaId == surveyId)
                    .Include(x => x.Pregunta)
                        .ThenInclude(x => x.EncuestaCategoria)
                            .ThenInclude(x => x.Categoria)
                    .Select(x => new
                    {
                        CategoriaId = x.Pregunta.EncuestaCategoria.CategoriaId,
                        CategoriaNombre = x.Pregunta.EncuestaCategoria.Categoria.NombreCategoria,
                        PreguntaId = x.PreguntaId,
                        TipoPreguntaID = x.Pregunta.TipoPreguntaId,
                        PreguntaNombre = x.Pregunta.NombrePregunta,
                        x.Valor,
                        x.DescripcionRespuesta,
                        x.Pregunta.TipoPreguntaId
                    })
                    .GroupBy(x => new { x.CategoriaId, x.CategoriaNombre })
                    .Select(g1 => new Categorias
                    {
                        CategoriaId = g1.Key.CategoriaId,
                        CategoriaNombre = g1.Key.CategoriaNombre,
                        PromedioGeneral = g1.Where(x => x.TipoPreguntaID == 2 || x.TipoPreguntaID == 6).Average(x => x.Valor),
                        Preguntas = g1.GroupBy(x => new { x.PreguntaId, x.PreguntaNombre, x.TipoPreguntaId })
                            .Select(g2 => new PreguntasBeneficios
                            {
                                PreguntaId = g2.Key.PreguntaId,
                                PreguntaNombre = g2.Key.PreguntaNombre,
                                TipoPreguntaId = g2.Key.TipoPreguntaId,
                                Promedio = g2.Where(x => x.TipoPreguntaId == 2).Average(x => x.Valor) ?? 0,
                                porcentaje = ((int?)(g2.Where(x => x.TipoPreguntaId == 2).Average(x => x.Valor) * 20) ?? 0),
                                Respuestas = g2.Select(z => new RespuestasBeneficios
                                {
                                    valor = z.Valor,
                                    DescripcionRespuesta = z.DescripcionRespuesta
                                }).ToList(),
                            }).ToList(),
                    })
                    .ToList();
            return Json(respuestasPorCategoria);
        }


        public JsonResult DatosMadurez(int surveyId = 2)
        {
            var respuestasPorCategoria = _context.RespuestaMadurezcs
                    .Where(x => x.EncuestaRepondente.EncuestaId == surveyId)
                    .Include(x => x.Pregunta)
                        .ThenInclude(x => x.EncuestaCategoria)
                            .ThenInclude(x => x.Categoria)
                    .Select(x => new
                    {
                        CategoriaId = x.Pregunta.EncuestaCategoria.CategoriaId,
                        CategoriaNombre = x.Pregunta.EncuestaCategoria.Categoria.NombreCategoria,
                        PreguntaId = x.PreguntaId,
                        TipoPreguntaID = x.Pregunta.TipoPreguntaId,
                        PreguntaNombre = x.Pregunta.NombrePregunta,
                        x.Valor,
                        x.DescripcionRespuesta,
                        x.Pregunta.TipoPreguntaId
                    })
                    .GroupBy(x => new { x.CategoriaId, x.CategoriaNombre })
                    .Select(g1 => new Categorias
                    {
                        CategoriaId = g1.Key.CategoriaId,
                        CategoriaNombre = g1.Key.CategoriaNombre,
                        PromedioGeneral = g1.Where(x => x.TipoPreguntaID == 2 || x.TipoPreguntaID == 6).Average(x => x.Valor),
                        Preguntas = g1.GroupBy(x => new { x.PreguntaId, x.PreguntaNombre, x.TipoPreguntaId })
                            .Select(g2 => new PreguntasBeneficios
                            {
                                PreguntaId = g2.Key.PreguntaId,
                                PreguntaNombre = g2.Key.PreguntaNombre,
                                TipoPreguntaId = g2.Key.TipoPreguntaId,
                                Promedio = g2.Where(x => x.TipoPreguntaId == 2).Average(x => x.Valor) ?? 0,
                                porcentaje = ((int?)(g2.Where(x => x.TipoPreguntaId == 2).Average(x => x.Valor) * 20) ?? 0),
                                Respuestas = g2.Select(z => new RespuestasBeneficios
                                {
                                    valor = z.Valor,
                                    DescripcionRespuesta = z.DescripcionRespuesta
                                }).ToList(),
                            }).ToList(),
                    }).ToList();
            return Json(respuestasPorCategoria);
        }
    }
}
