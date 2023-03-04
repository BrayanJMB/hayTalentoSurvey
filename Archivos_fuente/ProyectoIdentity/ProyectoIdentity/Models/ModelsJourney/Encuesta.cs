using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Encuesta
    {
        public int Id { get; set; }
        [Display(Name = "Nombre de la Encuesta")]
        [StringLength(100,ErrorMessage ="Ha excedido el tamaño maximo del Nombre")]
        public string NombreEncuesta { get; set; }
        [StringLength(int.MaxValue, ErrorMessage = "Ha excedido el tamaño maximo del Nombre")]
        [Display(Name = "Descripcion de la Encuesta")]
        public string DescripcionEncuesta { get; set; }
        public string? Cliente { get; set; }

        public string? Link { get; set; }

        public DateTime FechaDeCreacion { get; set; } = DateTime.Now;

        public DateTime FechaMaximoPlazo { get; set; }

        //llaves Foraneas
        [ForeignKey("Company")]
        public string CompanyId  { get; set; }
        
        public Company? Company { get; set; }

        //tablas de referencia
        //public List<EncuestaDemografico>? EncuestaDemograficos { get; set; }
        public List<EncuestaCategoria>? EncuestaCategorias { get; set; }

        public List<EncuestaDemografico>? Demograficos { get; set; }

        public List<EncuestaRepondente>? EncuestaRepondente { get; set; }

        public List<EncuestaBussines>? EncuestaBussines { get; set; }

        public List<EncuestaArea>? EncuestaAreas { get; set; }

        public List<EncuestaRespondenteB> RespondenteBeneficios { get; set; }
    }
}
