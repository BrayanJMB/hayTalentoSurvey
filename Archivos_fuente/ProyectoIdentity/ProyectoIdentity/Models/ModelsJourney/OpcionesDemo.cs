using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class OpcionesDemo
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [ForeignKey("Demograficos")]
        public int DemograficoId { get; set; }
        public Demograficos? Demograficos { get; set; }

    }
}
