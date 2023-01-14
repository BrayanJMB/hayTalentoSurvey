namespace ProyectoIdentity.Models.ModelTemplateJorney
{
    public class PreguntaDemografica
    {
        public string NombrePregunta  { get; set; }
        public string TipoPregunta { get; set; }
        public List<Opcion> Opciones { get; set; }
    }
}
