using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Pregunta
    {
        public int Id { get; set; }
        public string NombrePregunta { get; set; }
        //llaves Foraneas
        [ForeignKey("TipoPregunta")]
        public int TipoPreguntaId { get; set; }
        public TipoPregunta?  TipoPregunta { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        //
        public List<Respuesta>?  Respuestas { get; set; }
        public List<Opcion>? Opciones { get; set; }
    }
}
