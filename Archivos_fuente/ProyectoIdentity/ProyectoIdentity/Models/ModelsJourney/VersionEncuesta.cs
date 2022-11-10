using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class VersionEncuesta
    {
        public int Id { get; set; }
        [RegularExpression(@"^[0-9]{1,3}?$")]
        [Display(Name = "Numero de Version")]
        public int VersionNumber { get; set; }
        [DataType(DataType.Date, ErrorMessage = "{0} debe ser una fecha")]
        [Display(Name = "Fecha Maximo Plazo")]
        public DateTime FechaMaximoPlazo { get; set; }
        [DataType(DataType.Date, ErrorMessage = "{0} debe ser una fecha")]
        [Display(Name = "Fecha De Creacion")]
        public DateTime FechaCreacion { get; set; }
        [ForeignKey("Encuesta")]
        [JsonIgnore]
        public int EncuestaId { get; set; }
        public Encuesta? Encuesta { get; set; }

        //
        public List<Respondente>? Respondentes { get; set; }
    }
}
