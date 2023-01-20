using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Respondente
    {
        public Guid Id { get; set; }
        
        public string Country { get; set; }
        public string? City { get; set; }

        
        public string? Area { get; set; }
        public string? BussinesUnitId { get; set; }

        public List<EncuestaRepondente>? EncuestaRepondente { get; set; }
        public List<DemograficoPersonal>? Fammilia { get; set; }
        //public List<Respuesta>? Respuestas { get; set; }
        //public List<DemograficosName>? DemograficoName { get; set; }

        

    }
}
