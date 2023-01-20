using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class RespuestaMadurezcs
    {
        public int Id { get; set; }
        public string? DescripcionRespuesta { get; set; }

        public float? Valor { get; set; }

        [ForeignKey("Pregunta")]
        public int PreguntaId { get; set; }

        public Pregunta? Pregunta { get; set; }
        [ForeignKey("EncuestaRepondente")]
        public int EncuestaRespondenteID { get; set; }

        public EncuestaRepondente? EncuestaRepondente { get; set; }
    }
}
