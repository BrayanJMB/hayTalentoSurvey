using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class EncuestaCategoria
    {
        public int Id { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        [ForeignKey("Encuesta")]
        public int EncuestaId { get; set; }
        public Encuesta? Encuesta { get; set; }
        public List<Pregunta>? Preguntas { get; set; }
    }
}
