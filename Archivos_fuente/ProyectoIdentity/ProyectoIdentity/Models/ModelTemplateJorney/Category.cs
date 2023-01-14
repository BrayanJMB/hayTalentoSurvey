namespace ProyectoIdentity.Models.ModelTemplateJorney
{
    public class Category
    {
        public int Id { get; set; }
        public string NombreCategoria { get; set; }

        public List<Pregunta> Preguntas { get; set; }
        public List<PreguntaDemografica> PreguntaDemografica { get; set; }
    }
}
