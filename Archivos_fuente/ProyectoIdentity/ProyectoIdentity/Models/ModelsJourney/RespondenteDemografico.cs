namespace ProyectoIdentity.Models.ModelsJourney
{
    public class RespondenteDemografico
    {
        public int Id { get; set; }
        public Guid RespondenteId { get; set; }
        public Respondente? Respondente { get; set; }
        public int DemograficosId { get; set; }
        public Demograficos? Demograficos { get; set; }
        public string Respuesta { get; set; }
    }
}
