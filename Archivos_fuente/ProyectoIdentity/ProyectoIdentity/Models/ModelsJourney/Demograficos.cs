using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Demograficos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<RespondenteDemografico>? RespondenteDemograficos { get; set; }
        public List<EncuestaDemografico>? EncuestaDemografico { get; set; }
        public List<OpcionesDemo>? OpcionesDemo { get; set; }
    }
}
