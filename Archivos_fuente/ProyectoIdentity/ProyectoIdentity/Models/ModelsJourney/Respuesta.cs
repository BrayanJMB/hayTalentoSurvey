using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Respuesta
    {
        public string DescripcionRespuesta { get; set; }

        //llaves Foraneas
   
        public Guid RespondenteId { get; set; }
        public Respondente? Respondente { get; set; }

        public int PreguntaId { get; set; }

        public Pregunta? Pregunta { get; set; }
    }
}
