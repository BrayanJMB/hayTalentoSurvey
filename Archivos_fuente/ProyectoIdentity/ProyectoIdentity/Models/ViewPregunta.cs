using ProyectoIdentity.Models.ModelsJourney;
using ProyectoIdentity.Models.ModelTemplateJorney;

namespace ProyectoIdentity.Models
{
    public class ViewPregunta
    {
        public string NombrePregunta { get; set; }
        public string NombreTipoPregunta { get; set; }
        public string NombreCategoria { get; set; }
        public List<Opciones> Opcion { get; set; }

    }
}
