using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class DemograficoPersonal
    {
        public int Id { get; set; }

        public string Parentesco { get; set; }

        public string? Sexo { get; set; }

        public string? EstadoCivil { get; set; }

        public string? NivelEducativo { get; set; }

        public string?  DependenciaEconomica { get; set; }

        public string? Edad { get; set; }
        [ForeignKey("Respondente")]
        public Guid?  RespondenteId { get; set; }

        public Respondente? Respondente { get; set; }
    }
}
