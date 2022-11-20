using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Company: IdentityUser
    {
        [Display(Name = "Nombre de la Compañia")]
        [StringLength(200, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Name { get; set; }
        [Display(Name = "Direccion")]
        [StringLength(80, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Adress { get; set; }
        [Display(Name = "Nombre Completo Usuario")]
        [StringLength(80, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        
        public string PersonFullName { get; set; }
        [Display(Name = "Estado del usuario")]
        public bool Activo { get; set; } = false;
        
        public List<Encuesta>? Encuestas { get; set; }
    }
}
