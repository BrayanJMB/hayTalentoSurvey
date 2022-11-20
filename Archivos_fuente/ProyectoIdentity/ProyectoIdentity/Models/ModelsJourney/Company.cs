using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Company: IdentityUser
    {
        public int CompanyId { get; set; }
        [Display(Name = "Nombre de la Compañia")]
        [StringLength(200, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Name { get; set; }
        [Display(Name = "Direccion")]
        [StringLength(80, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string Adress { get; set; }
        [Display(Name = "Correo Electronico")]
        [StringLength(80, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]
        public string  Email { get; set; }
        [Display(Name = "Numero Telefonico")]
        [RegularExpression(@"^(\(\+?\d{2,3}\)[\*|\s|\-|\.]?(([\d][\*|\s|\-|\.]?){6})(([\d][\s|\-|\.]?){2})?|(\+?[\d][\s|\-|\.]?){8}(([\d][\s|\-|\.]?){2}(([\d][\s|\-|\.]?){2})?)?)$",
                            ErrorMessage = "Digite un Numero Telefonico"
                            )]
        public string PhoneNumber { get; set; }
        [Display(Name = "Nombre Completo Encargado")]
        [StringLength(110, ErrorMessage = "El {0} no puede superar los {1} Caracteres")]

        public string PersonFullName { get; set; }
        [Display(Name = "Estado del usuario")]
        public bool Activo { get; set; } = false;
        
        public List<Encuesta>? Encuestas { get; set; }
    }
}
