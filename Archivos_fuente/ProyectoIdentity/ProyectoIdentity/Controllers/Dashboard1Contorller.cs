using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;
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
    public class SurveyShow
    {
        public string NombreCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
        public List<dataPreguntas> datospreguntas { get; set; }

        public string Preguntasimple { get; set; }

        public List<DictionaryClod> nubePalabras { get; set; }

        public Encuesta Encuesta { get; set; }//Nuevo campo
    }
    public class dataPreguntas
    {
        public string? mispreguntas { get; set; }

        public float valores { get; set; } = 0;
        public int porcentaje { get; set; }
        public string Color { get; set; }
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
        public List<RespuestasBeneficios> Respuestas { get; set; }

    }

    public class RespuestasBeneficios
    {
        public float? valor { get; set; }
        public string DescripcionRespuesta { get; set; }

    }


    public class Dashboard1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private SurveyShow _surveyShow;
        private string[] colores = { "bg-danger", "bg-danger", "bg-warning", "bg-info", "", "bg-success" };
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
                                Color = colores[(int)g.Average(x => x.Valor)]
                            }).ToList();
            _surveyShow.NombreCategoria = category.NombreCategoria;
            _surveyShow.DescripcionCategoria = category.Descripcion;
            _surveyShow.datospreguntas = datospreguntas;
            _surveyShow.Preguntasimple = _context.Pregunta.Where(x => x.TipoPreguntaId == 5 && x.EncuestaCategoria.EncuestaId == surveyId).Select(x => x.NombrePregunta).FirstOrDefault();
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
            return View(_surveyShow);
        }

        public IActionResult Index2(int surveyId)
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
                    CategoriaId = x.Pregunta.EncuestaCategoria.CategoriaId,
                    CategoriaNombre = x.Pregunta.EncuestaCategoria.Categoria.NombreCategoria,
                    CategoriaDescripcion=x.Pregunta.EncuestaCategoria.Categoria.Descripcion,
                    PreguntaId = x.PreguntaId,
                    NumeroPregunta=x.Pregunta.NumeroPregunta,
                    TipoPreguntaID=x.Pregunta.TipoPreguntaId,
                    PreguntaNombre = x.Pregunta.NombrePregunta,
                    x.Valor,
                    x.DescripcionRespuesta,
                    x.Pregunta.TipoPreguntaId
                })
                .GroupBy(x => new { x.CategoriaId, x.CategoriaNombre,x.CategoriaDescripcion })
                .Select(g1 => new Categorias
                {
                    CategoriaId = g1.Key.CategoriaId,
                    CategoriaNombre = g1.Key.CategoriaNombre,
                    CategoriaDescripcion=g1.Key.CategoriaDescripcion,
                    Preguntas = g1.GroupBy(x => new { x.PreguntaId, x.PreguntaNombre,x.TipoPreguntaId,x.NumeroPregunta})
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
                            Color = colores[((int?)g2.Where(x => x.TipoPreguntaId == 2).Average(x => x.Valor)) ?? 0],
                            CantidadRespuestas = g2.Count()
                        }).ToList()
                }).ToList();

            return View(respuestasPorCategoria);
        }
    }
}
