using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models.ModelosRespuestas;
using ProyectoIdentity.Models.ModelsJourney;
using ProyectoIdentity.Models.ModelTemplateJorney;

namespace ProyectoIdentity.Controllers
{
    public class SurveyNew
    {
        public string NombreEncuesta { get; set; }
        public int Id { get; set; }
        public string DescripcionEncuesta { get; set; }
        public List<Country> Paises { get; set; }
        public List<Area> Area { get; set; }

        public List<BusinessUnit> Negocios { get; set; }
        public List<Demograficos> Demograficos { get; set; }
        public string[] CapitalesColombia { get; set; }

        public List<Category> Categorias { get; set; }

    }
    
    public class RespuestasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RespuestasController(ApplicationDbContext context)
        {
            _context = context;
        }


        //Vista de respuestas 
        public async Task<IActionResult> IndexRespuestas(int idSurvey)
        {
            ViewBag.Message = "Login";
            var encuestallegada =await _context.Encuesta.Where(x => x.Id == idSurvey).FirstOrDefaultAsync();
            if (encuestallegada != null) { 

            var Country = await _context.Country.Include(p => p.Cities).ToListAsync();
            var area =  _context.EncuestaArea.Where(e => e.EncuestaId == idSurvey).Include(p => p.Area).Select(p => p.Area).ToList();
            var Bussinee = await _context.EncuestaBussines.Where(x => x.EncuestaId == idSurvey).
                Include(b => b.BusinessUnit).Select(b => b.BusinessUnit).ToListAsync();
            //demograficos de la encuesta
            var demograficos = await _context.EncuestaDemografico
                .Where(ed => ed.EncuestaId == idSurvey)
                .Include(ed => ed.Demograficos.OpcionesDemo)
                .Select(ed => ed.Demograficos)
                .ToListAsync();
            string[] capitales = _context.City.Where(p => p.CountryId == "Colombia").Select(x=>x.CityName).ToArray();
            
            var query = await
                (from encuesta in _context.Encuesta
                 join encuestaCate in _context.EncuestaCategoria
                 on encuesta.Id equals encuestaCate.EncuestaId
                 join categoria in _context.Categoria
                 on encuestaCate.CategoriaId equals categoria.Id
                 where encuesta.Id == idSurvey
                 select new SurveyNew
                 {
                     NombreEncuesta = encuesta.NombreEncuesta,
                     Id = encuesta.Id,
                     DescripcionEncuesta = encuesta.DescripcionEncuesta,
                     Categorias = (from encuestaCate in _context.EncuestaCategoria
                                   join categoria in _context.Categoria
                                   on encuestaCate.CategoriaId equals categoria.Id
                                   where encuestaCate.EncuestaId == idSurvey
                                   select new Category
                                   {
                                       NombreCategoria = categoria.NombreCategoria,
                                       Id = categoria.Id,
                                       Description=categoria.Descripcion,
                                       Preguntas = (from pregunta in _context.Pregunta
                                                    where pregunta.EncuestaCategoriaId == categoria.Id
                                                    select new Models.ModelTemplateJorney.Pregunta
                                                    {
                                                        NombrePregunta = pregunta.NombrePregunta,
                                                        IdTipo = pregunta.TipoPreguntaId,
                                                        NumeroPregunta = pregunta.NumeroPregunta,
                                                        IdPregunta=pregunta.Id,
                                                        TipoPregunta = (from tipoPregunta in _context.TipoPregunta
                                                                        where pregunta.TipoPreguntaId == tipoPregunta.Id
                                                                        select tipoPregunta.NombreTipoPregunta).FirstOrDefault(),
                                                        Opciones = (from opciones in _context.Opcion
                                                                    where pregunta.Id == opciones.PreguntaId
                                                                    select new Models.ModelTemplateJorney.Opcion
                                                                    {
                                                                        OpcionName = opciones.Nombre,
                                                                        ValorOPcion=opciones.ValorOpcion
                                                                    }).ToList()
                                                    }).ToList()
                                   }).ToList()
                 }).FirstOrDefaultAsync();

            try { 
                query.Demograficos = demograficos;
                query.Paises= Country;
                query.Area=area;
                query.Negocios= Bussinee;
                query.CapitalesColombia = capitales;
            }catch(Exception ex)
            {
                return RedirectToAction("Error", "Cuentas");
            }
            return View(query);
            }
            else
            {
                return RedirectToAction("Error", "Cuentas");
            }
        }
        //Respuestas Vista de descripcion categorias
        public async Task<IActionResult> RedirectIndexRespuestas(int idSurvey)
        {

            ViewBag.Message = "EnvioRedirectRespuestas";
            
            var query = (from encuesta in _context.Encuesta
                         where encuesta.Id == idSurvey
                         select new Encuesta
                         {
                             Id = idSurvey,
                             NombreEncuesta = encuesta.NombreEncuesta,
                             DescripcionEncuesta = encuesta.DescripcionEncuesta
                         }).FirstOrDefault();
            if (query == null)
            {
                return View("Error");
            }
            return View(query);
        }
        //respuesta Categorias
        public async Task<IActionResult> EnvioIndexRespuestas(int idEndcuesta,
            Respondente Res,
            List<RespuestasConvalor> resValor,
            List<RespuestasDeCheck> resCheck,
            List<RespuestaPersonalizada> resPer,
            List<RespuestasConvalor> resNumer)
        {
            ViewBag.Message = "Login";
            return View();
        }


        ////////////Encuesta Madurez//////////////////////////

        public async Task<IActionResult> IndexRespuestasMadurez(int idSurvey)
        {
            
            ViewBag.Message = "Login";
            var query = await
                            (from encuesta in _context.Encuesta
                             join encuestaCate in _context.EncuestaCategoria
                             on encuesta.Id equals encuestaCate.EncuestaId
                             join categoria in _context.Categoria
                             on encuestaCate.CategoriaId equals categoria.Id
                             where encuesta.Id == idSurvey
                             select new SurveyNew
                             {
                                 NombreEncuesta = encuesta.NombreEncuesta,
                                 Id = encuesta.Id,
                                 DescripcionEncuesta = encuesta.DescripcionEncuesta,
                                 Categorias = (from encuestaCate in _context.EncuestaCategoria
                                               join categoria in _context.Categoria
                                               on encuestaCate.CategoriaId equals categoria.Id
                                               where encuestaCate.EncuestaId == idSurvey
                                               select new Category
                                               {
                                                   NombreCategoria = categoria.NombreCategoria,
                                                   Description=categoria.Descripcion,
                                                   Preguntas = (from pregunta in _context.Pregunta
                                                                where pregunta.EncuestaCategoriaId == categoria.Id
                                                                select new Models.ModelTemplateJorney.Pregunta
                                                                {
                                                                    NombrePregunta = pregunta.NombrePregunta,
                                                                    IdTipo = pregunta.TipoPreguntaId,
                                                                    IdPregunta=pregunta.Id,
                                                                    NumeroPregunta = pregunta.Id,
                                                                    TipoPregunta = (from tipoPregunta in _context.TipoPregunta
                                                                                    where pregunta.TipoPreguntaId == tipoPregunta.Id
                                                                                    select tipoPregunta.NombreTipoPregunta).FirstOrDefault(),
                                                                    Opciones = (from opciones in _context.Opcion
                                                                                where pregunta.Id == opciones.PreguntaId
                                                                                select new Models.ModelTemplateJorney.Opcion
                                                                                {
                                                                                    OpcionName = opciones.Nombre
                                                                                }).ToList()
                                                                }).ToList()
                                               }).ToList()
                             }).FirstOrDefaultAsync();
            return View(query);
        }
        //vista Entrada MAdurez
        public async Task<IActionResult> RedirectIndexRespuestasMadurez(int idSurvey)
        {
            ViewBag.Message = "EnvioRedirectRespuestasMadurez";
            var query = (from encuesta in _context.Encuesta
                         where encuesta.Id == idSurvey
                         select new Encuesta
                         {
                             Id=idSurvey,
                             NombreEncuesta = encuesta.NombreEncuesta,
                             DescripcionEncuesta = encuesta.DescripcionEncuesta
                         }).FirstOrDefault();
            return View(query);
        }
        //envio respuestas de madurez 
        public async Task<IActionResult> EnvioIndexRespuestasMadurez(int IdEncuesta, List<int> IdPregunta,List<int> ValueRespuesta,string LabelRespuesta)
        {
            var Respouestas =new List<RespuestaMadurezcs>();
            int index = 0;
            var encuestaRespo =await _context.EncuestaRepondente.AddAsync(new EncuestaRepondente
            {
                EncuestaId = IdEncuesta,
                RespuestasMadurez = Respouestas,
                PonderadoRespuesta = (ValueRespuesta.Sum() / ValueRespuesta.Count())
            });
            await _context.SaveChangesAsync();

            foreach (var respuesta in ValueRespuesta)
            {
                Respouestas.Add(new RespuestaMadurezcs
                {
                    PreguntaId = IdPregunta[index],
                    Valor=respuesta,
                    EncuestaRespondenteID=encuestaRespo.Entity.Id

                });
                index++;
            }
            Respouestas.Add(new RespuestaMadurezcs
            {
                DescripcionRespuesta = LabelRespuesta,
                PreguntaId = IdPregunta[index],
                EncuestaRespondenteID = encuestaRespo.Entity.Id

            });

            await _context.AddRangeAsync(Respouestas);
            await _context.SaveChangesAsync();
            //Guardar el repondente




            ViewBag.Message = "Login";
            return View();
        }
    }
}
