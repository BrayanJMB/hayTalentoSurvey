namespace ProyectoIdentity.Models.ModelsJourney
{
    public class TipoPregunta
    {
        public int Id { get; set; }
        public string NombreTipoPregunta { get; set; }
        public string Descripcion { get; set; }
        //
        public Pregunta? Pregunta { get; set; }
    }
}
