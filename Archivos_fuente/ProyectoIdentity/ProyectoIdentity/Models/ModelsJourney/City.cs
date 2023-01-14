using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class City
    {
        [Key]
        [MaxLength(255)]
        public string CityName  { get; set; }
        [ForeignKey("Country")]
        [MaxLength(255)]
        public string CountryId { get; set; }

        public Country? Country { get; set; }
    }
}
