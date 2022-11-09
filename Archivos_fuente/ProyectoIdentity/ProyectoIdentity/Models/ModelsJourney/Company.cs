namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }

        public string Adress { get; set; }
        public string  Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonFullName { get; set; }
        //
        public List<AppUsuario> AppUsuarios { get; set; }
        //Tablas De referencia
        public List<Encuesta>? Encuestas { get; set; }
    }
}
