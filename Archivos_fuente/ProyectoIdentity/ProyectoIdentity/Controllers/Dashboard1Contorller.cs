using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models.ModelosRespuestas;
using ProyectoIdentity.Models.ModelsJourney;
using ProyectoIdentity.Models.ModelTemplateJorney;
using System.Linq;

namespace ProyectoIdentity.Controllers
{
    public class DictionaryClod
    {
        public string Key { get; set; }
        public int value { get; set; }
    }
    public class listDemographics
    {
        public List<DictionaryClod> Paises { get; set; }

        public List<DictionaryClod> Ciudades { get; set; }

        public List<DictionaryClod> Negocios { get; set; }

        public List<DictionaryClod> Areas { get; set; }
    }
    public class SurveyShow
    {
        public string Cliente { get; set; }
        public string NombreCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
        public List<dataPreguntas> datospreguntas { get; set; }
        public string Preguntasimple { get; set; }
        public List<DictionaryClod> nubePalabras { get; set; }
        public Encuesta Encuesta { get; set; }//Nuevo campo
        public List<OpcionPorcentaje> PorcentajePromedio { get; set; }

        public Models.ModelsJourney.Pregunta Pregunta { get; set; }

        public int  CantidadRespuestas { get; set; }
    }

    public class dataPreguntas
    {
        public string? mispreguntas { get; set; }
        public int? numeroPregunta { get; set; }
        public float Promedio { get; set; }
        public float valores { get; set; } = 0;
        public int porcentaje { get; set; }
        public string Color { get; set; }
    }

    public class valuesPersonales {
        public int a { get; set; }
        public string b { get; set; }

        public int c { get; set; }
    }

   


    public class Categorias
    {
        
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; }
        public string CategoriaDescripcion { get; set; }
        public List<PreguntasBeneficios> Preguntas { get; set; }
        public float? PromedioGeneral { get; set; } // Nueva propiedad agregada
        public int surveyId { get; set; } //campo nuevo
        public Encuesta Encuesta {get;set; }//campo nuevo

        
    }

    public class orderBycategory {
        public string Cliente { get; set; }
        public int ContadorRespuestas { get; set; } 
        public List<Categorias> Categorias { get; set; }
        public Respuestaper QuestionPer { get; set; }
        public listDemographics Demograficos { get; set; }

        public List<valuesPersonales> DatosPersonales { get; set; }

        public List<valuesPersonales> DatosPersonalesFamilia { get; set; }

        public double Hijos { get; set; }

        public double Hermanos { get; set; }

        public double DependenciaEc0nomica { get; set; }

    }

    public class Respuestaper
    {
        public string NombrePregunta { get; set; }
        public List<RespuestaPersonalizada> Respuestas { get; set; }

        
    }

    public class DemograficosAnswer {

        public string Ciudad { get; set; }
        public string Pais { get; set; }

        public string Area { get; set; }

        public string Negocios { get; set; }
    }

    public class PreguntasBeneficios
    {
        public int PreguntaId { get; set; }
        public string PreguntaNombre { get; set; }
        public float Promedio { get; set; }
        public string Color { get; set; }
        public int NumeroPregunta { get; set; }
        public int porcentaje { get; set; }
        public int TipoPreguntaId { get; set; }
        public int CantidadRespuestas { get; set; }
        public List<string> Opciones { get; set; }
        public List<RespuestasBeneficios> Respuestas { get; set; }
    }

    public class RespuestasBeneficios
    {
        public float? valor { get; set; }
        public string DescripcionRespuesta { get; set; }
        public string? RespuestaOpcion { get; set; }

    }

    public class OpcionPorcentaje
    {
        public string Opcion { get; set; }
        public double Porcentaje { get; set; }

        public int Promedio { get; set; }

        public string Color { get; set; }
    }


    public class Dashboard1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private SurveyShow _surveyShow;
        private string[] colores = { "bg-danger", "bg-danger", "bg-danger", "bg-warning", "bg-primary", "bg-success" };
        public Dashboard1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int surveyId)
        {
            var encuesta = _context.Encuesta.FirstOrDefault(e => e.Id == surveyId);
            _surveyShow = new SurveyShow();
            var category = _context.EncuestaCategoria.Include(x => x.Categoria)
                .Where(x => x.EncuestaId == surveyId)
                .Select(x => new { x.Categoria.NombreCategoria, x.Categoria.Descripcion })
                .FirstOrDefault();

            var datospreguntas = new List<dataPreguntas>();
            datospreguntas = _context.RespuestaMadurezcs
                            .Include(x => x.Pregunta).Where(x => x.Pregunta.TipoPreguntaId == 2)
                            .GroupBy(x => x.Pregunta.Id)
                            .Select(g => new dataPreguntas
                            {
                                mispreguntas = g.First().Pregunta.NombrePregunta,
                                valores = g.Average(x => (float)Math.Round((decimal)x.Valor, 2)),
                                porcentaje = (int)(g.Average(x => x.Valor) * 20),
                                Color = colores[(int)Math.Ceiling((double)g.Average(x => x.Valor))],
                                Promedio = g.Where(x => x.Pregunta.TipoPreguntaId == 2).Average(x => x.Valor) ?? 0,
                                numeroPregunta = g.First().Pregunta.NumeroPregunta,

                            }).ToList();
            _surveyShow.NombreCategoria = category.NombreCategoria;
            _surveyShow.DescripcionCategoria = category.Descripcion;
            _surveyShow.datospreguntas = datospreguntas;
            _surveyShow.Cliente = encuesta.Cliente;

            var pregunta = _context.Pregunta
            .Include(x => x.Opciones)
            .FirstOrDefault(x => x.TipoPreguntaId == 3 && x.EncuestaCategoria.EncuestaId == surveyId);
            var respuestas = _context.RespuestaMadurezcs.Where(x => x.PreguntaId == pregunta.Id);
            var porcentajePorOpcion = pregunta.Opciones
            .GroupBy(x => x.NumeroOpcion)
            .Select(g => new OpcionPorcentaje
            {
                Promedio = (int)respuestas.Where(x => x.Valor == g.Key).Count(),
                Opcion = g.First().Nombre,
                Porcentaje = respuestas.Where(x => x.Valor == g.Key).Count() * 100 / respuestas.Count(),
                Color = colores[(int?)Math.Ceiling((double)respuestas.Where(x => x.Valor == g.Key).Count() * 5 / respuestas.Count())??0],
            }
            ).ToList();



            var nubepalabras = _context.RespuestaMadurezcs.Include(x => x.Pregunta).Where(x => x.Pregunta.TipoPreguntaId == 5 && x.Pregunta.EncuestaCategoria.EncuestaId == surveyId).Select(x => x.DescripcionRespuesta).ToArray();
            string nubeWords = String.Join(",", nubepalabras);
            nubepalabras = nubeWords.Split(' ', '.', ',', ';', ':', '-', '!', '?')
                                    .Where(p => p.ToLower() != "de" &&
                                    p.ToLower() != "como" &&
                                    p.ToLower() != "ir" &&
                                    p.ToLower() != "y" &&
                                    p.ToLower() != "para" &&
                                    p.ToLower() != "a"
                                    ).Distinct()
                                    .ToArray();
            _surveyShow.nubePalabras = nubepalabras.Select(x => new DictionaryClod { Key = x, value = 2 }).ToList();
            _surveyShow.Encuesta = encuesta;
            _surveyShow.PorcentajePromedio = porcentajePorOpcion;
            _surveyShow.Pregunta = pregunta;
            _surveyShow.CantidadRespuestas = respuestas.Count();
            return View(_surveyShow);
        }

        public IActionResult Index2(int surveyId)
        {
            var cantRespuestas = _context.EncuestaRespondenteB.Where(x => x.EncuestaId == surveyId).Count();
            if (cantRespuestas < 1)
                return View(RedirectToAction("Index", "Encuestas"));
            
            var categorias = _context.EncuestaCategoria.Include(x => x.Categoria)
                .Include(x => x.Preguntas)

                .Where(x => x.EncuestaId == surveyId)
                .Select(x => x.Categoria).ToList();

            var respuestasPorCategoria = _context.Respuesta
                .Where(x => x.EncuestaRespondenteB.EncuestaId == surveyId)
                .Include(x => x.Pregunta)                    
                    .ThenInclude(x => x.EncuestaCategoria)
                        .ThenInclude(x => x.Categoria)
                .Include(x => x.Pregunta.Opciones)
                .Select(x => new
                {
                    CategoriaId = x.Pregunta.EncuestaCategoria.CategoriaId,
                    CategoriaNombre = x.Pregunta.EncuestaCategoria.Categoria.NombreCategoria,
                    CategoriaDescripcion=x.Pregunta.EncuestaCategoria.Categoria.Descripcion,
                    PreguntaId = x.PreguntaId,
                    NumeroPregunta=x.Pregunta.NumeroPregunta,
                    TipoPreguntaID=x.Pregunta.TipoPreguntaId,
                    PreguntaNombre = x.Pregunta.NombrePregunta,
                    x.Valor,
                    x.DescripcionRespuesta,
                    x.Pregunta.TipoPreguntaId,
                    x.Pregunta.Opciones
                })
                .GroupBy(x => new { x.CategoriaId, x.CategoriaNombre,x.CategoriaDescripcion })
                .Select(g1 => new Categorias
                {
                    CategoriaId = g1.Key.CategoriaId,
                    CategoriaNombre = g1.Key.CategoriaNombre,
                    CategoriaDescripcion=g1.Key.CategoriaDescripcion,
                    Preguntas = g1.GroupBy(x => new { x.PreguntaId, x.PreguntaNombre,x.TipoPreguntaId,x.NumeroPregunta, x.Opciones })
                        .Select(g2 => new PreguntasBeneficios
                        {
                            PreguntaId = g2.Key.PreguntaId,
                            PreguntaNombre = g2.Key.PreguntaNombre,
                            TipoPreguntaId=g2.Key.TipoPreguntaId,
                            NumeroPregunta=g2.Key.NumeroPregunta,
                            Promedio = g2.Where(x => x.TipoPreguntaId == 2).Average(x => x.Valor) ?? 0,
                            porcentaje= ((int?)(g2.Where(x => x.TipoPreguntaId == 2).Average(x => x.Valor)*20) ?? 0),
                            Respuestas = g2.Select(z =>   new RespuestasBeneficios
                            {
                                valor = z.Valor,
                                DescripcionRespuesta = z.DescripcionRespuesta
                            }).ToList(),
                            Color = colores[((int?)Math.Ceiling((double)g2.Where(x => x.TipoPreguntaId == 2).Average(x => x.Valor))) ?? 0],
                            CantidadRespuestas = g2.Count(),
                            Opciones=g2.Key.Opciones.Select(g3=>g3.Nombre).ToList()
                        }).ToList()
                }).ToList();

            return View(respuestasPorCategoria);
        }
    }
}
