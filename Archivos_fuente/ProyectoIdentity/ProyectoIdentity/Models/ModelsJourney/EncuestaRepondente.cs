namespace ProyectoIdentity.Models.ModelsJourney
{
    public class EncuestaRepondente
    {
        public int EncuestaId { get; set; }
        public Guid RespondenteId { get; set; }

        public DateTime FechaRespuesta { get; set; }
    }
}
