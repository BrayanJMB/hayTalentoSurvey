namespace ProyectoIdentity.Models.ModelTemplateJorney
{
    public class Pregunta
    {
        public string NombrePregunta  { get; set; }
        public string TipoPregunta { get; set; }
        public int IdTipo { get; set; }
        public int NumeroPregunta { get; set; }

        public List<Opcion> Opciones { get; set; }
    }
}
