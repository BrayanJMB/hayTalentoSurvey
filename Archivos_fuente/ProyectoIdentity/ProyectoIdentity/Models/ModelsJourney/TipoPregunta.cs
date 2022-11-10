using System.ComponentModel.DataAnnotations;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class TipoPregunta
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string NombreTipoPregunta { get; set; }
        [Display(Name = "Descripcion")]
        [StringLength(350, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]

        public string Descripcion { get; set; }
        //
        public Pregunta? Pregunta { get; set; }
    }
}
