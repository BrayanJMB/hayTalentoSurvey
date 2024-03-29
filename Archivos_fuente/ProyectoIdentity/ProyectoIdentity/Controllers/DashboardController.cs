﻿using Microsoft.AspNetCore.Authorization;
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
        private string[] colores = { "bg-danger", "bg-danger", "bg-danger", "bg-warning", "bg-primary", "bg-success" };

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

            var encuesta = _context.Encuesta.FirstOrDefault(e => e.Id == surveyId);

            var cantRespuestas = _context.EncuestaRespondenteB.Where(x => x.EncuestaId == surveyId).Count();
            if (cantRespuestas < 1)
                return RedirectToAction("Index","Encuestas");

            //var preguntaPersonalizada=_context.Encuesta.
            var respuestasPorCategoria = _context.Respuesta
                .Where(x => x.EncuestaRespondenteB.EncuestaId == surveyId)
                .Include(x => x.Pregunta)
                    .ThenInclude(x => x.EncuestaCategoria)
                        .ThenInclude(x => x.Categoria)
                .Include(y=>y.Pregunta.Opciones)
                .Select(x => new
                {
                    CategoriaId = x.Pregunta.EncuestaCategoria.CategoriaId,
                    CategoriaNombre = x.Pregunta.EncuestaCategoria.Categoria.NombreCategoria,
                    CategoriaDescripcion = x.Pregunta.EncuestaCategoria.Categoria.Descripcion,
                    PreguntaId = x.PreguntaId,
                    NumeroPregunta = x.Pregunta.NumeroPregunta,
                    TipoPreguntaID = x.Pregunta.TipoPreguntaId,
                    PreguntaNombre = x.Pregunta.NombrePregunta,
                   
                    x.Valor,
                    x.DescripcionRespuesta,
                    x.Pregunta.TipoPreguntaId,
                    x.RespuestaOpcion,
                    
                    Opciones=x.Pregunta.Opciones.Select(y=>y.Nombre).ToList(),

                })
                .GroupBy(x => new { x.CategoriaId, x.CategoriaNombre, x.CategoriaDescripcion})
                .Select(g1 => new Categorias
                {
                    CategoriaId = g1.Key.CategoriaId,
                    CategoriaNombre = g1.Key.CategoriaNombre,
                    CategoriaDescripcion = g1.Key.CategoriaDescripcion,
                    surveyId = surveyId,
                    Encuesta= encuesta,
                    PromedioGeneral = g1.Where(x => x.TipoPreguntaID == 2 || x.TipoPreguntaID == 6).Average(x => x.Valor),
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
                                DescripcionRespuesta = z.DescripcionRespuesta,
                                RespuestaOpcion=z.RespuestaOpcion

                            }).ToList(),
                            Color = colores[(int?)Math.Ceiling((double)g2.Where(x => x.TipoPreguntaId == 2).Average(x => x.Valor)) ?? 0],
                            CantidadRespuestas = g2.Count(),
                            Opciones=g2.First().Opciones
                        }).ToList()
                }).ToList();

            var pregunta17 = _context.Pregunta.Where(x => x.NumeroPregunta == 17 && x.EncuestaCategoria.EncuestaId == surveyId).FirstOrDefault().NombrePregunta;
            var respuestas = _context.RespuestaPersonalizada.Where(x => x.IdPregunta == 17 && x.EncuestaRespondenteB.EncuestaId == surveyId).ToList();
            var response17 = new Respuestaper { NombrePregunta = pregunta17, Respuestas = respuestas };
            //Demograficos de todos los ususarto
            
            var demograficos = _context.EncuestaRespondenteB.Where(x => x.EncuestaId == surveyId).Select(x => new DemograficosAnswer
            {
                Area = x.Respondente.Area,
                Negocios = x.Respondente.BussinesUnitId,
                Ciudad = x.Respondente.City,
                Pais = x.Respondente.Country
            }).ToList();

            var paises = demograficos.Select(x => x.Pais).GroupBy(x => x).Select(x => new DictionaryClod{
                Key=x.Key,
                value = (int)Math.Round((double)x.Count() / demograficos.Count() * 100, 2)
            }).ToList();

            var negocios = demograficos.Select(x => x.Negocios).GroupBy(x => x).Select(x => new DictionaryClod
            {
                Key = x.Key,
                value = (int)Math.Round((double)x.Count() / demograficos.Count() * 100, 2)
            }).ToList();

            var areas = demograficos.Select(x => x.Area).GroupBy(x => x).Select(x => new DictionaryClod
            {
                Key = x.Key,
                value = (int)Math.Round((double)x.Count() / demograficos.Count() * 100, 2)
            }).ToList();

            var ciudades = demograficos.Select(x => x.Ciudad).GroupBy(x => x).Select(x => new DictionaryClod
            {
                Key = x.Key,
                value = (int)Math.Round((double)x.Count() / demograficos.Count() * 100, 2)
            }).ToList();

            //aspetos personales de cada usuario
            var datosPersonales = _context.EncuestaRespondenteB.Include(x=>x.Respondente.Fammilia).Where(x => x.EncuestaId == surveyId).Select(x => x.Respondente.Fammilia.Where(x=>x.Parentesco=="Colaborador")).ToList();
            var NivelEducativo = datosPersonales.GroupBy(x =>  x.FirstOrDefault().NivelEducativo).ToList().Select(x => new valuesPersonales
            {
                a = 2,
                b = x.Key.ToString(),
                c = x.Count() * 100 / cantRespuestas
            }).ToList();
            var Edad = datosPersonales.GroupBy(x => x.FirstOrDefault().Edad).ToList().Select(x => new valuesPersonales
            {
                a = 3,
                b = x.Key.ToString(),
                c = x.Count() * 100 / cantRespuestas
            }).ToList();
            var estadoCivil = datosPersonales.GroupBy(x => x.FirstOrDefault().EstadoCivil).ToList().Select(x => new valuesPersonales
            {
                a = 1,
                b = x.Key.ToString(),
                c = x.Count() * 100 / cantRespuestas
            }).ToList();
            var Sexo = datosPersonales.GroupBy(x => x.FirstOrDefault().Sexo).ToList().Select(x => new valuesPersonales
            {
                a = 0,
                b = x.Key.ToString(),
                c = x.Count() * 100 / cantRespuestas
            }).ToList();
            Sexo.AddRange(estadoCivil);
            Sexo.AddRange(NivelEducativo);
            Sexo.AddRange(Edad);
            //aspectos personales por familiar
            var datosPersonalesFamiliar = _context.EncuestaRespondenteB.Include(x => x.Respondente.Fammilia)
                .Where(x => x.EncuestaId == surveyId)
                .SelectMany(x => x.Respondente.Fammilia
                .Where(x => x.Parentesco != "Colaborador" && !string.IsNullOrEmpty(x.Parentesco))).ToList();
            int count = datosPersonalesFamiliar.
    Where(x=>x.EstadoCivil!="Fallecido")
    .Count();
            var hijos = (double)datosPersonalesFamiliar.Count(x => x.Parentesco == "Hijo")/count;
            var hermanos= (double)datosPersonalesFamiliar.Count(x => x.Parentesco == "Hermano")/count;
            var dependenciaeco= (double)datosPersonalesFamiliar.Count(x => x.DependenciaEconomica == "Sí")/count;
            var NivelEducativof = datosPersonalesFamiliar.Where(x=>x.NivelEducativo!=null).GroupBy(x => x.NivelEducativo)?.ToList().Select(x => new valuesPersonales
            {
                a = 2,
                b = x.Key.ToString(),
                c = x.Count() * 100 / count
            }).ToList();
            var Edadf = datosPersonalesFamiliar.Where(x => x.Edad != null).GroupBy(x => x.Edad).ToList().Select(x => new valuesPersonales
            {
                a = 3,
                b = x.Key.ToString(),
                c = x.Count() * 100 / count
            }).ToList();
            var estadoCivilf = datosPersonalesFamiliar.Where(x => x.EstadoCivil != null).GroupBy(x => x.EstadoCivil).ToList().Select(x => new valuesPersonales
            {
                a = 1,
                b = x.Key.ToString(),
                c = x.Count() * 100 / datosPersonalesFamiliar.Count()
            }).ToList();
            var Sexof = datosPersonalesFamiliar.Where(x => x.Sexo != null).GroupBy(x => x.Sexo).ToList().Select(x => new valuesPersonales
            {
                a = 0,
                b = x.Key.ToString(),
                c = x.Count() * 100 / datosPersonalesFamiliar.Count()
            }).ToList();
            Sexof.AddRange(estadoCivilf);
            Sexof.AddRange(NivelEducativof);
            Sexof.AddRange(Edadf);

            var datos2 = new orderBycategory {
                ContadorRespuestas = cantRespuestas,
                Categorias = respuestasPorCategoria,
                QuestionPer = response17,
                Cliente= encuesta.Cliente,
                Demograficos = new listDemographics
                {
                    Areas = areas,
                    Ciudades = ciudades,
                    Negocios = negocios,
                    Paises = paises
                },
                DatosPersonales = Sexo,
                DatosPersonalesFamilia=Sexof,
                DependenciaEc0nomica=dependenciaeco,
                Hijos=hijos,
                Hermanos=hermanos
            };
            


            return View(datos2);
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
        public JsonResult DatosDemograficos(int surveyId)
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


        public JsonResult DatosMadurez(int surveyId)
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
