using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Demograficos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("Encuesta")]
        public int IdEncuesta { get; set; }
        public Encuesta? Encuesta { get; set; }

        public int NumeroDemografico { get; set; }
        //public List<EncuestaDemografico>? encuestaDemograficos { get; set; }

        public List<RespondenteDemografico>? RespondenteDemograficos { get; set; }
        public List<OpcionesDemo>? OpcionesDemo { get; set; }
    }
}
