using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Respondente
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string UnidadNegocio { get; set; }

        public string Area { get; set; }
        public string Parentesco { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }

        public string NivelEducativo { get; set; }

        public string DependienteEconomicamente { get; set; }

        public string Edad { get; set; }
        //llaves foraneas
        [ForeignKey("Version")]
        public int VersionId { get; set; }

        public VersionEncuesta? Version { get; set; }

        //
        public FechaRespuesta? FechaRespuesta { get; set; }
        public List<Respuesta>? Respuestas { get; set; }



    }
}
