using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Pregunta
    {
        public int Id { get; set; }
        [Display(Name = "Pregunta")]
        [StringLength(500, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string NombrePregunta { get; set; }

        public string? DescripcionPregunta { get; set; }
        public int NumeroPregunta { get; set; }

        //llaves Foraneas
        [ForeignKey("TipoPregunta")]
        [Display(Name = "Clase de Pregunta")]
        public int TipoPreguntaId { get; set; }
        public TipoPregunta?  TipoPregunta { get; set; }
        [ForeignKey("EncuestaCategoria")]
        public int EncuestaCategoriaId { get; set; }
        public EncuestaCategoria? EncuestaCategoria { get; set; }

        //
        public List<Respuesta>?  Respuestas { get; set; }
        public List<Opcion>? Opciones { get; set; }
    }
}
