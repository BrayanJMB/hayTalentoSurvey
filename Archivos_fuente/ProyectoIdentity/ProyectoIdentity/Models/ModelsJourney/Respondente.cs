using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Respondente
    {
        public Guid Id { get; set; }
        [StringLength(250, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Nombre { get; set; }
        [StringLength(50, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Ciudad { get; set; }
        [Display(Name = "Unidad de Negocio")]
        [StringLength(50, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string UnidadNegocio { get; set; }
        [StringLength(50, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Area { get; set; }
        [StringLength(50, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Parentesco { get; set; }
        [StringLength(50, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Sexo { get; set; }
        [Display(Name = "Estado Civil")]
        [StringLength(50, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string EstadoCivil { get; set; }
        [Display(Name = "Nivel Educativo")]
        [StringLength(50, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]

        public string NivelEducativo { get; set; }
        [Display(Name = "DependienteEconomicamente")]
        [StringLength(50, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string DependienteEconomicamente { get; set; }
        [RegularExpression(@"^[0-9]{1,2}?$",ErrorMessage ="Edad No valida, Digite edad ")]
        public string Edad { get; set; }
        //llaves foraneas
        [ForeignKey("Version")]
        [Display(Name = "Version")]
        public int VersionId { get; set; }

        public VersionEncuesta? Version { get; set; }

        //
        public FechaRespuesta? FechaRespuesta { get; set; }
        public List<Respuesta>? Respuestas { get; set; }



    }
}
