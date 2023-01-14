using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class EncuestaArea
    {
        public int Id { get; set; }
        [ForeignKey("Encuesta")]
        public int EncuestaId { get; set; }
        [ForeignKey("Area")]
        public string AreaId { get; set; }

        public Area? Area { get; set; }
        public Encuesta? Encuesta { get; set; }
    }
}
