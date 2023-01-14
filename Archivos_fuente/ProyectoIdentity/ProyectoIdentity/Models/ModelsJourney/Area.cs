using System.ComponentModel.DataAnnotations;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Area
    {
        [Key]
        public string AreaName { get; set; }

        public List<Respondente>? Respondentes { get; set; }
    }
}
