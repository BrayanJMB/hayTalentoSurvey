using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Country
    {
        [Key]
        [MaxLength(255)]
        public string CountryName { get; set; }
        [JsonIgnore]
        public List<City>? Cities { get; set; }
    }
}
