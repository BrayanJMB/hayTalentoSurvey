using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class VersionEncuesta
    {
        public int Id { get; set; }
        public int VersionNumber { get; set; }
        public DateTime FechaMaximoPlazo { get; set; }
        public DateTime FechaCreacion { get; set; }
        [ForeignKey("Encuesta")]
        public int EncuestaId { get; set; }
        public Encuesta? Encuesta { get; set; }

        //
        public List<Respondente>? Respondentes { get; set; }
    }
}
