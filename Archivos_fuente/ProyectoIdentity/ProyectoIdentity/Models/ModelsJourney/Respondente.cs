using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Respondente
    {
        public Guid Id { get; set; }
        [StringLength(250, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public List<RespondenteDemografico>? RespondenteDemograficos { get; set; }
        public List<EncuestaRepondente>? EncuestaRepondente { get; set; }
        public List<Respuesta>? Respuestas { get; set; }



    }
}
