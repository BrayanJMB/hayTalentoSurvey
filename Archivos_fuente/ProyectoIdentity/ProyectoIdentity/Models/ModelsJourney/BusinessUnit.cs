using System.ComponentModel.DataAnnotations;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class BusinessUnit
    {
        [Key]
        public string NameBusinnes { get; set; }

        public List<Respondente>? Respondentes { get; set; }
    }
}
