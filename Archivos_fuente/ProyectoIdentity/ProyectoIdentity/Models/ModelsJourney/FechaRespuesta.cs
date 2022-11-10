using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class FechaRespuesta
    {
        public int Id { get; set; }
        [DataType(DataType.Date, ErrorMessage = "{0} debe ser una fecha")]
        [Display(Name = "Fecha de respuesta")]
        public DateTime FechaDeRespuesta { get; set; }
        //llaves Foraneas
        [ForeignKey("Respondente")]
        [Display(Name = "Persona que responde")]
        public Guid RespondenteId { get; set; }

        
        public Respondente? Respondente { get; set; }
    }
}
