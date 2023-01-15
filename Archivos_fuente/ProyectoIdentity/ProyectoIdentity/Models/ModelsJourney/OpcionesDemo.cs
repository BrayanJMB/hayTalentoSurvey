using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class OpcionesDemo
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [ForeignKey("Demograficos")]
        public int DemograficoId { get; set; }
        [JsonIgnore]
        public Demograficos? Demograficos { get; set; }

    }
}
