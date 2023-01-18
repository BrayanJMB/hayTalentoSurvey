
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models.ModelsJourney;
using ProyectoIdentity.Models.ModelTemplateJorney;
using System.Linq;
using System.Linq.Expressions;
using Opcion = ProyectoIdentity.Models.ModelTemplateJorney.Opcion;
using Pregunta = ProyectoIdentity.Models.ModelTemplateJorney.Pregunta;
using PreguntDB= ProyectoIdentity.Models.ModelsJourney.Pregunta;

namespace ProyectoIdentity.Controllers
{
    public class EditPreguntas
    {
        public Encuesta Encuesta { get; set; }
        public List<PreguntDB> preguntas { get; set; }
    }
    [Authorize]
    public class EncuestasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        //private Dictionary<string, string> preguntasBase = new();
        public EncuestasController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
            var preguntas =
            ViewBag.Encuesta = encuesta;
            Model.Categorias = ModelSurvey.Categories2();
            //Funcionalidad Paises

            var paises = await _context.Country.Select(x => x.CountryName).ToListAsync();
            var areas = await _context.Area.Select(x => x.AreaName).ToListAsync();
            var negpocios = await _context.BusinessUnit.Select(x => x.NameBusinnes).ToListAsync();
            var opcionespaises = new List<Opcion>();
            int count = 1;
            foreach (var pais in paises)
            {
                opcionespaises.Add(new Opcion { Id = count, OpcionName = pais });
                count++;
            }
            //agregar las opciones nuevas de areas y Negocios

            //funcionalidad Ciudades
            var Ciudades = await _context.City.ToListAsync();
            Model.Ciudades = Ciudades;
            var pregunta1 = new List<Pregunta>{
                new Pregunta {NombrePregunta="Pais",NumeroPregunta=1,TipoPregunta="Respuesta Unica",Opciones=opcionespaises},
                new Pregunta {NombrePregunta= "Ciudad",NumeroPregunta=2,TipoPregunta="Respuesta Unica"},
                new Pregunta {NombrePregunta= "Area",NumeroPregunta=3,TipoPregunta= "Respuesta Unica", },
                new Pregunta { NombrePregunta = "Unidad de Negocio",NumeroPregunta=4,TipoPregunta= "Respuesta Unica"}
            };
            Model.Categorias[0].Preguntas = pregunta1;

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
                //creacion de encuesta
                Encuesta Encuesta = new Encuesta
                {
                    CompanyId = encuesta.CompanyId,
                    DescripcionEncuesta = encuesta.DescripcionEcuesta,
                    FechaDeCreacion = encuesta.FechaDeCreacion,
                    FechaMaximoPlazo = encuesta.Fechalimite,
                    NombreEncuesta = encuesta.NombreEncuesta
                };
                var encuestaRes = await _context.Encuesta.AddAsync(Encuesta);
                
                _context.SaveChanges();
                _context.EncuestaCategoria.Add(new EncuestaCategoria
                {
                    CategoriaId = encuesta.CategoriaR[0].Idcategoria,
                    EncuestaId=encuestaRes.Entity.Id
                });
                _context.EncuestaCategoria.Add(new EncuestaCategoria
                {
                    CategoriaId = encuesta.CategoriaR[1].Idcategoria,
                    EncuestaId = encuestaRes.Entity.Id
                });
                await _context.SaveChangesAsync();
                encuestaRes.Entity.Link = _configuration.GetValue<string>("LinkSurvey") + "?idSurvey=" + encuestaRes.Entity.Id;
                _context.Encuesta.Update(encuestaRes.Entity);
                //demograficos Tablas Area Y negocios                    
                List<string> datosAreas = encuesta.CategoriaR[0].Preguntas.Where(p => p.Nombre == "Area").Select(x => x.Opciones).First().Select(y => y.NombreOpcion.ToLower()).ToList();
                List<string> areas = new();
                if (datosAreas != null)
                {
                    List<string> opcionesDatabase = await _context.Area.Select(x => x.AreaName.ToLower()).ToListAsync();
                    if (opcionesDatabase.Count > 0)
                        areas = datosAreas.Except(opcionesDatabase.Select(x => x.ToLower())).ToList();
                    else
                        areas = datosAreas;
                }


                var datosNegocio = encuesta.CategoriaR[0].Preguntas.Where(p => p.Nombre == "Unidad de Negocio").Select(p => p.Opciones).First().Select(y => y.NombreOpcion.ToLower()).ToList();
                List<string> negocios = new();
                if (datosNegocio != null)
                {
                    var opcionesNegocios = await _context.BusinessUnit.Select(a => a.NameBusinnes).ToListAsync();
                    if (opcionesNegocios.Count > 0)
                        negocios = datosNegocio.Except(opcionesNegocios.Select(x => x.ToLower())).ToList();
                    else
                        negocios = datosNegocio;
                }
                List<Area> AreasNuevas = new List<Area>();
                List<BusinessUnit> NegociosNuevos = new();
                List<EncuestaArea> AreasEncuesta = new();
                List<EncuestaBussines> negociosEncuesta = new();
                foreach (var area in areas)
                {
                    AreasNuevas.Add(new Area { AreaName = area });

                }
                foreach (var area in datosAreas)
                {
                    AreasEncuesta.Add(new EncuestaArea { AreaId = area, EncuestaId = encuestaRes.Entity.Id });
                }
                foreach (var negocio in negocios)
                {
                    NegociosNuevos.Add(new BusinessUnit { NameBusinnes = negocio });

                }

                foreach (var negocio in datosNegocio)
                {
                    negociosEncuesta.Add(new EncuestaBussines { BusinessUnitId = negocio, EncuestaId = encuestaRes.Entity.Id });
                }

                await _context.Area.AddRangeAsync(AreasNuevas);
                await _context.SaveChangesAsync();
                await _context.BusinessUnit.AddRangeAsync(NegociosNuevos);
                await _context.EncuestaBussines.AddRangeAsync(negociosEncuesta);
                await _context.EncuestaArea.AddRangeAsync(AreasEncuesta);

                //espacio para demograficos
                var demograficos = encuesta.CategoriaR[1];
                encuesta.CategoriaR.Remove(demograficos);
                encuesta.CategoriaR.Remove(encuesta.CategoriaR[0]);
                var beneficios =new List<CategoriaR> {encuesta.CategoriaR.Last()};
                encuesta.CategoriaR.Remove(encuesta.CategoriaR.Last());
                //crear los demograficos
                int index = 1;
                foreach(var demografico in demograficos.Preguntas)
                {
                    var demo=_context.Demograficos.Add(new Demograficos
                    {
                        NumeroDemografico=index,
                        Nombre=demografico.Nombre,
                        
                    });
                    await _context.SaveChangesAsync();
                    await _context.EncuestaDemografico.AddAsync(new EncuestaDemografico
                    {
                        DemograficoId = demo.Entity.Id,
                        EncuestaId= encuestaRes.Entity.Id
                    });
                    index++;
                    foreach(var opciones  in demografico.Opciones)
                    {
                        await _context.OpcionesDemo.AddAsync(new OpcionesDemo
                        {
                            DemograficoId = demo.Entity.Id,
                            Name = opciones.NombreOpcion

                        });
                    }
                    await _context.SaveChangesAsync();
                }
                //otras dimensiones diferentes a demograficas
                bool exito=await CreateSurvey(encuesta.CategoriaR, encuestaRes.Entity.Id);
                var EncuestaMadurez = new Encuesta
                {
                    CompanyId = encuesta.CompanyId,
                    DescripcionEncuesta = encuesta.DescripcionEcuesta,
                    FechaDeCreacion = encuesta.FechaDeCreacion,
                    FechaMaximoPlazo = encuesta.Fechalimite,
                    NombreEncuesta = encuesta.NombreEncuesta + "-Madurez"
                };
                var encuestaMadRes = await _context.Encuesta.AddAsync(EncuestaMadurez);
                await _context.SaveChangesAsync();
                encuestaMadRes.Entity.Link = _configuration.GetValue<string>("LinkSurveyMadurez") + "?idSurvey=" + encuestaMadRes.Entity.Id;
                _context.Encuesta.Update(encuestaMadRes.Entity);
                //agregar los datos demograficos
                bool exito2 =await CreateSurvey(beneficios, encuestaMadRes.Entity.Id);
                //Modificar las preguntas
                //Listado de preguntas una por una
                //Retornar vistas de preguntas donde el id de la encuasta sea el creado anterioremente
                return RedirectToAction(nameof(Index1));
            }
            //ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", encuesta.CompanyId);
            return RedirectToAction(nameof(Index1));
        }

        //Ir a la vista para editar las encuestas
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Encuesta == null)
            {
                return NotFound();
            }
            var encuesta =await _context.Encuesta.Where(d => d.Id == id).FirstOrDefaultAsync();
            var preguntas = await _context.Pregunta.Where(p => p.EncuestaCategoria.EncuestaId == id).ToListAsync();
            EditPreguntas data = new EditPreguntas { Encuesta = encuesta, preguntas = preguntas };
            
            //ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", encuesta.CompanyId);
            return View(data);
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
        //Metodo para crar la encuesta
        private async Task<bool> CreateSurvey(List<CategoriaR>encuesta, int idSurvey)
        {
#pragma warning disable CS0168 // La variable 'Ex' se ha declarado pero nunca se usa
            try
            {
                int numeroPregunta = 1;

                foreach (var categories in encuesta)
                {
                    var preguntaCa = await _context.EncuestaCategoria.AddAsync(new EncuestaCategoria
                    {
                        CategoriaId = categories.Idcategoria,
                        EncuestaId = idSurvey
                    }); ;
                    await _context.SaveChangesAsync();
                    foreach (var preguntas in categories.Preguntas)
                    {

                        var pregunntap = await _context.Pregunta.AddAsync(new Models.ModelsJourney.Pregunta
                        {
                            NombrePregunta = preguntas.Nombre,
                            DescripcionPregunta = preguntas.Descripcion,
                            EncuestaCategoriaId = preguntaCa.Entity.Id,
                            TipoPreguntaId = preguntas.TipoPreguntaId,
                            NumeroPregunta = numeroPregunta
                        });
                        await _context.SaveChangesAsync();
                        int numeroOpcion = 1;
                        if (preguntas.Opciones.Count > 0)
                        {
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
                        numeroPregunta++;
                    }
                    
                }
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
#pragma warning restore CS0168 // La variable 'Ex' se ha declarado pero nunca se usa

        }

    }




}
