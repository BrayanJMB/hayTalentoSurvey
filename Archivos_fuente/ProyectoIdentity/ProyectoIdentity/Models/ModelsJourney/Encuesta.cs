using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Encuesta
    {
        public int Id { get; set; }
        public string NombreEncuesta { get; set; }
        public string DescripcionEncuesta { get; set; }

        //llaves Foraneas
        [ForeignKey("Company")]
        public int CompanyId  { get; set; }
        
        public Company? Company { get; set; }

        //tablas de referencia
        public List<Categoria>? Categorias { get; set; }

        public List<VersionEncuesta>? Versions { get; set; }
    }
}
