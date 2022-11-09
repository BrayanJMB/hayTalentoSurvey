using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Opcion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int NumeroOpcion { get; set; }
        [ForeignKey("Pregunta")]
        public int PreguntaId { get; set; }

        public Pregunta? Pregunta { get; set; }
    }
}
