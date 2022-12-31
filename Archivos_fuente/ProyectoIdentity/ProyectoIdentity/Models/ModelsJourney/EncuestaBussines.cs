using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class EncuestaBussines
    {
        public int Id { get; set; }
        [ForeignKey("Encuesta")]
        public int EncuestaId { get; set; }
        [ForeignKey("BusinessUnit")]
        public string BusinessUnitId { get; set; }

        public Encuesta? Encuesta { get; set; }

        public BusinessUnit? BusinessUnit { get; set; }
    }
}
