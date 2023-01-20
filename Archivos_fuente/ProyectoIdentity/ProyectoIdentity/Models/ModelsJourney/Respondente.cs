using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Respondente
    {
        public Guid Id { get; set; }
        
        [ForeignKey("Country")]
        [MaxLength(255)]
        public string CountryId { get; set; }
        [ForeignKey("City")]
        public string? CityId { get; set; }

        [ForeignKey("Area")]

        public string? AreaId { get; set; }

        [ForeignKey("BusinessUnit")]

        public string? BussinesUnitId { get; set; }

        public List<EncuestaRepondente>? EncuestaRepondente { get; set; }
        public List<DemograficoPersonal>? Fammilia { get; set; }
        //public List<Respuesta>? Respuestas { get; set; }
        //public List<DemograficosName>? DemograficoName { get; set; }

        public BusinessUnit? BusinessUnit { get; set; }

        public Area? Area { get; set; }

        public City? City { get; set; }

        public Country? Country { get; set; }



    }
}
