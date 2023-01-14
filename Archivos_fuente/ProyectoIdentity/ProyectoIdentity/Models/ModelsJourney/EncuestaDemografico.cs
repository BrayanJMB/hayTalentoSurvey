using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class EncuestaDemografico
    {
        public int Id { get; set; }
        [ForeignKey("Demograficos")]
        public int DemograficoId { get; set; }
        [ForeignKey("Encuesta")]
        public int EncuestaId { get; set; }

        public Encuesta? Encuesta { get; set; }

        public Demograficos? Demograficos { get; set; }
    }
}
