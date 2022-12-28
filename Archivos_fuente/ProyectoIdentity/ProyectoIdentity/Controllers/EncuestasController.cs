
using Mailjet.Client.Resources.SMS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models.ModelsJourney;
using ProyectoIdentity.Models.ModelTemplateJorney;
using System.Linq;
using Opcion = ProyectoIdentity.Models.ModelTemplateJorney.Opcion;
using Pregunta = ProyectoIdentity.Models.ModelTemplateJorney.Pregunta;

namespace ProyectoIdentity.Controllers
{
    public class EncuestasController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private Dictionary<string, string> preguntasBase = new();
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
        //Vista Para encuesta no modificable
        public async Task<IActionResult> Index1()
        {
            var appDbContext = _context.Encuesta.Include(e => e.Company);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> IndexCreaPreguntas(Encuesta encuesta)
        {
            var Model = new ModelSurvey();
            var preguntas=
            ViewBag.Encuesta = encuesta;
            Model.Categorias = ModelSurvey.Categories();
            //Funcionalidad Paises
            
            var paises =await _context.Country.Select(x=>x.CountryName).ToListAsync();
            var opcionespaises = new List<Opcion>();
            int count = 1;
            foreach(var pais in paises)
            {
                opcionespaises.Add(new Opcion { Id = count, OpcionName = pais });
                count++;    
            }

            //funcionalidad Ciudades
            var Ciudades = await _context.City.ToListAsync();
            Model.Ciudades = Ciudades;
            var pregunta1 = new List<Pregunta>{
                new Pregunta {NombrePregunta="Pais",NumeroPregunta=1,TipoPregunta="Respuesta Unica",Opciones=opcionespaises},
                new Pregunta {NombrePregunta= "Ciudad",NumeroPregunta=2,TipoPregunta="Respuesta Unica"},
                new Pregunta {NombrePregunta= "Area",NumeroPregunta=3,TipoPregunta= "Respuesta Unica" },
                new Pregunta { NombrePregunta = "Unidad de Negocio",NumeroPregunta=4,TipoPregunta= "Respuesta Unica"}
            };
            Model.Categorias[0].Preguntas=pregunta1;

            return View(Model);
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
            
            var cantidadRespondente = (from x in _context.EncuestaRepondente
                        where x.EncuestaId == id
                            select x).Count();
            ViewData["respondestesEncuensta"] = cantidadRespondente;
            return View(encuesta);
        }

        // GET: Encuestas/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Encuesta data)
        {
            ViewData["Encuesta"] = data;
            return View();
        }




        // POST: Encuestas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEncuestas(data encuesta)
        {
            
            if (ModelState.IsValid)
            {
                Encuesta Encuesta = new Encuesta
                {
                    CompanyId = encuesta.CompanyId,
                    DescripcionEncuesta=encuesta.DescripcionEcuesta,
                    FechaDeCreacion=encuesta.FechaDeCreacion,
                    FechaMaximoPlazo=encuesta.Fechalimite,
                    NombreEncuesta=encuesta.NombreEncuesta
                    
                };
                var encuestaRes = await _context.Encuesta.AddAsync(Encuesta);
                //_context.SaveChanges();
                //espacio para demograficos
                var datosAreas = encuesta.CategoriaR[0].Preguntas.Where(p=>p.Nombre=="Area").Select(x=>x.Opciones).First();
                //var datosArea2 = datosAreas.Except(_context.Area.Select(a=>a.AreaName).ToList());
                var datosNegocio = encuesta.CategoriaR[0].Preguntas.Where(p => p.Nombre == "Unidad Negocio").Select(p => p.Opciones).First();
                var demograficos = encuesta.CategoriaR[1];
                encuesta.CategoriaR.Remove(demograficos);
                encuesta.CategoriaR.Remove(encuesta.CategoriaR[0]);
                //otras dimensiones diferentes a demograficas
                int numeroPregunta = 1;
                foreach (var categories in encuesta.CategoriaR)
                {
                    var preguntaCa=await _context.EncuestaCategoria.AddAsync(new EncuestaCategoria
                    {
                        CategoriaId = categories.Idcategoria,
                        EncuestaId = encuestaRes.Entity.Id
                    });
                    await _context.SaveChangesAsync();
                    foreach(var preguntas in categories.Preguntas)
                    {

                        var pregunntap = await _context.Pregunta.AddAsync(new Models.ModelsJourney.Pregunta
                        {
                            NombrePregunta=preguntas.Nombre,
                            DescripcionPregunta="falta esta parte",
                            EncuestaCategoriaId = preguntaCa.Entity.Id,
                            TipoPreguntaId = preguntas.TipoPreguntaId,
                            NumeroPregunta=numeroPregunta
                            
                        });
                        await _context.SaveChangesAsync();
                        int numeroOpcion = 1;
                        if (preguntas.Opciones.Count > 0) { 
                        foreach (var opc in preguntas.Opciones)
                        {
                            await _context.Opcion.AddAsync(new Models.ModelsJourney.Opcion
                            {
                                Nombre = opc.NombreOpcion,
                                NumeroOpcion = numeroOpcion,
                                PreguntaId = pregunntap.Entity.Id,
                                ValorOpcion = (5 / preguntas.Opciones.Count) * numeroOpcion
                            });
                            
                            numeroOpcion++;
                        }
                        }
                        await _context.SaveChangesAsync();
                    }
                    numeroPregunta++;
                }
                

                //agregar las Categorias

                //agregar las preguntas

                //Agregar Opciones Existentes

                //Modificar las preguntas
                //Listado de preguntas una por una
                //Retornar vistas de preguntas donde el id de la encuasta sea el creado anterioremente
                return RedirectToAction(nameof(Index1));
            }
            //ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", encuesta.CompanyId);
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
            //ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", encuesta.CompanyId);
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
            //ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", encuesta.CompanyId);
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
