using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class EncuestaDemografico
    {
        public int Id { get; set; }
        [ForeignKey("Encuesta")]
        public int IdEncuesta { get; set; }
        public Encuesta? Encuesta { get; set; }
        [ForeignKey("Demografico")]
        public int IdDemografico { get; set; }
        public Demograficos? Demografico { get; set; }
    }
}
