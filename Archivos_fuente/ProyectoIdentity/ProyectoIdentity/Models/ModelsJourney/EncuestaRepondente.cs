using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class EncuestaRepondente
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Encuesta")]
        public int EncuestaId { get; set; }
        [ForeignKey("Respondente")]
        public Guid? RespondenteId { get; set; }

        public DateTime FechaRespuesta { get; set; }= DateTime.Now;

        public List<RespuestaMadurezcs>? RespuestasMadurez { get; set; }

        public int PonderadoRespuesta { get; set; }

        public Encuesta? Encuesta { get; set; }

        public Respondente? Respondente { get; set; }
    }
}
