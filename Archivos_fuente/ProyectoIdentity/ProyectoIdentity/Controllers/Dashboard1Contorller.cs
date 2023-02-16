using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;

namespace ProyectoIdentity.Controllers
{
    public class SurveyShow {
        public string NombreCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
        public List<dataPreguntas> datospreguntas { get; set; }
    }
    public class dataPreguntas
    {
        public string? mispreguntas { get; set; }

        public float valores { get; set; } = 0;
        public int porcentaje { get; set; }
        public string Color { get; set; }
    }

    public class Dashboard1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private SurveyShow _surveyShow;
        private string[] colores= { "bg-danger", "bg-danger", "bg-warning", "bg-info", "", "bg-success" };
        public Dashboard1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int surveyId=2)
        {
            
            _surveyShow = new SurveyShow();
            var category = _context.EncuestaCategoria.Include(x=>x.Categoria)
                .Where(x=>x.EncuestaId==surveyId)
                .Select(x => new { x.Categoria.NombreCategoria, x.Categoria.Descripcion })
                .FirstOrDefault();

            var datospreguntas=new List<dataPreguntas>();
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
            _surveyShow.datospreguntas=datospreguntas;

            var nubepalabras = _context.RespuestaMadurezcs.Include(x => x.Pregunta).Where(x => x.Pregunta.TipoPreguntaId == 5 && x.Pregunta.EncuestaCategoria.EncuestaId == surveyId).Select(x => x.DescripcionRespuesta).ToList();
            return View(_surveyShow);
        }
    }
}
