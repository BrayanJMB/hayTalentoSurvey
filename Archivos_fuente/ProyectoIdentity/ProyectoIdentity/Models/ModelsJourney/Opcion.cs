using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Opcion
    {
        public int Id { get; set; }
        [Display(Name = "Opcion")]
        [StringLength(50, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Numero Opcion")]
        [RegularExpression(@"^[0-9]{1,2}?$")]
        public int NumeroOpcion { get; set; }
        [ForeignKey("Pregunta")]
        [JsonIgnore]
        [Display(Name = "Pregunta Numero")]
        public int PreguntaId { get; set; }

        public Pregunta? Pregunta { get; set; }
    }
}
