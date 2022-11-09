using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class FechaRespuesta
    {
        public int Id { get; set; }
        public DateTime FechaDeRespuesta { get; set; }
        //llaves Foraneas
        [ForeignKey("Respondente")]
        public Guid RespondenteId { get; set; }

        
        public Respondente? Respondente { get; set; }
    }
}
