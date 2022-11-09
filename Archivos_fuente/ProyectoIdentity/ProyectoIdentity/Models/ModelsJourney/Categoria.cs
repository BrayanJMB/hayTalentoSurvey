using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Categoria
    {
        public int  Id { get; set; }
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        //
        public List<Pregunta>? Preguntas { get; set; }


        //LLaves Foraneas
        [ForeignKey("Encuesta")]
        public int EncuestaId { get; set; }

        public Encuesta? Encuesta { get; set; }
    }
}
