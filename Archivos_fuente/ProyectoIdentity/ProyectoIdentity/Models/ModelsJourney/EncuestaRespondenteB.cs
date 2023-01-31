using ProyectoIdentity.Models.ModelosRespuestas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class EncuestaRespondenteB
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Encuesta")]
        public int EncuestaId { get; set; }
        [ForeignKey("Respondente")]
        public Guid? RespondenteId { get; set; }

        public DateTime FechaRespuesta { get; set; } = DateTime.Now;

        public List<Respuesta>? RespuestasBeneficios { get; set; }
        public List<RespuestaPersonalizada>?  RespuestaPersonalizada { get; set; }

        public Encuesta? Encuesta { get; set; }

        public Respondente? Respondente { get; set; }
    }
}
