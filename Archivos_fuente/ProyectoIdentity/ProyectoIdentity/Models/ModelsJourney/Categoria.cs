using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Categoria
    {
        public int  Id { get; set; }
        [Display(Name = "Nombre Categoria")]
        [StringLength(100, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string NombreCategoria { get; set; }
        [StringLength(300, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Descripcion { get; set; }
        public List<Pregunta>? Preguntas { get; set; }
        public List<EncuestaCategoria>? EncuestaCategoria { get; set; }
    }
}
