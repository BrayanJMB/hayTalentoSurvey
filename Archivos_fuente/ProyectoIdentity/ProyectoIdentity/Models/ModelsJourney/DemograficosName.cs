using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class DemograficosName
    {
        public int Id { get; set; }
        public string? Parentezco { get; set; }
        public string? Sexo { get; set; }

        public string? Estadocivil { get; set; }

        public string? NivelEducativo { get; set; }

        public string? DependenciaEconomica { get; set; }

        public string? Edad { get; set; }
        [ForeignKey("Respondente")]
        public Guid RespondenteId { get; set; }

        public Respondente? Respondente { get; set; }
    }
}
