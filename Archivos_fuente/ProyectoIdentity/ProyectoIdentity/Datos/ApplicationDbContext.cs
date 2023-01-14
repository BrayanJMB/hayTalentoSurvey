using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Models.ModelsJourney;


namespace ProyectoIdentity.Datos
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        //Agregamos los diferentes modelos que necesitamos

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Encuesta> Encuesta { get; set; }
        public DbSet<Opcion> Opcion { get; set; }
        public DbSet<Pregunta> Pregunta { get; set; }

        public DbSet<DemograficosName> DemograficosName { get; set; }

        public DbSet<Respondente> Respondente { get; set; }
        public DbSet<Respuesta> Respuesta { get; set; }
        public DbSet<TipoPregunta> TipoPregunta { get; set; }
        public DbSet<EncuestaRepondente> EncuestaRepondente { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<OpcionesDemo> OpcionesDemo { get; set; }
        public DbSet<Demograficos> Demograficos { get; set; }
        public DbSet<EncuestaCategoria> EncuestaCategoria { get; set; }
        public DbSet<EncuestaDemografico> EncuestaDemografico { get; set; }
        public DbSet<Area> Area { get; set; }

        public DbSet<Country> Country { get; set; }
        public DbSet<BusinessUnit> BusinessUnit { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<EncuestaArea> EncuestaArea { get; set; }

        public DbSet<EncuestaBussines> EncuestaBussines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Categoria> categorias = new List<Categoria> {
                    new Categoria{Id=1,NombreCategoria="Beneficios de Calidad de Vida" },
                    new Categoria{Id=2,NombreCategoria="Beneficios Monetarios y No Monetarios" },
                    new Categoria{Id=3,NombreCategoria="Beneficios de Desarrollo Personal" },
                    new Categoria{Id=4,NombreCategoria="Beneficios en Herramientas de Trabajo" },
                    new Categoria{Id=5,NombreCategoria="Beneficios/Madurez" }
        };

            List<TipoPregunta> tipoPreguntas = new List<TipoPregunta> {
                    new TipoPregunta{Id=1,NombreTipoPregunta="Respuesta Unica"},
                    new TipoPregunta{Id=2,NombreTipoPregunta="Likkert"},
                    new TipoPregunta{Id=3,NombreTipoPregunta="Seleccion Multiple"},
                    new TipoPregunta{Id=4,NombreTipoPregunta="Valoracion Multiple"},
                    new TipoPregunta{Id=5,NombreTipoPregunta="Abierta"},
                    new TipoPregunta{Id=6,NombreTipoPregunta="Multiple Likkert"}
            };

            List<Country> Paises = new List<Country>
            {
                new Country{CountryName="Antigua y Barbuda"},
                new Country{CountryName="Argentina"},
                new Country{CountryName="Bahamas"},
                new Country{CountryName="Barbados"},
                new Country{CountryName="Belice"},
                new Country{CountryName="Bolivia"},
                new Country{CountryName="Brasil"},
                new Country{CountryName="Canadá"},
                new Country{CountryName="Chile"},
                new Country{CountryName="Colombia"},
                new Country{CountryName="Costa Rica"},
                new Country{CountryName="Cuba"},
                new Country{CountryName="Dominica"},
                new Country{CountryName="Ecuador"},
                new Country{CountryName="El Salvador"},
                new Country{CountryName="Estados Unidos"},
                new Country{CountryName="Granada"},
                new Country{CountryName="Guatemala"},
                new Country{CountryName="Guyana"},
                new Country{CountryName="Haití"},
                new Country{CountryName="Honduras"},
                new Country{CountryName="Jamaica"},
                new Country{CountryName="México"},
                new Country{CountryName="Nicaragua"},
                new Country{CountryName="Panamá"},
                new Country{CountryName="Paraguay"},
                new Country{CountryName="Perú"},
                new Country{CountryName="República Dominicana"},
                new Country{CountryName="San Cristóbal y Nieves"},
                new Country{CountryName="San Vicente y las Granadinas"},
                new Country{CountryName="Santa Lucía"},
                new Country{CountryName="Surinam"},
                new Country{CountryName="Trinidad y Tobago"},
                new Country{CountryName="Uruguay"},
                new Country{CountryName="Venezuela"}
            };

            List<City> Ciudades = new List<City>
            {
                new City{CountryId="Colombia",CityName="Bogotá"},
                new City{CountryId="Colombia",CityName="Medellín"},
                new City{CountryId="Colombia",CityName="Cali"},
                new City{CountryId="Colombia",CityName="Barranquilla"},
                new City{CountryId="Colombia",CityName="Cartagena"},
                new City{CountryId="Colombia",CityName="Soledad"},
                new City{CountryId="Colombia",CityName="Cúcuta"},
                new City{CountryId="Colombia",CityName="Ibagué"},
                new City{CountryId="Colombia",CityName="Soacha"},
                new City{CountryId="Colombia",CityName="Villavicencio"},
                new City{CountryId="Colombia",CityName="Bucaramanga"},
                new City{CountryId="Colombia",CityName="Santa Marta"},
                new City{CountryId="Colombia",CityName="Valledupar"},
                new City{CountryId="Colombia",CityName="Bello"},
                new City{CountryId="Colombia",CityName="Pereira"},
                new City{CountryId="Colombia",CityName="Montería"},
                new City{CountryId="Colombia",CityName="Pasto"},
                new City{CountryId="Colombia",CityName="Buenaventura"},
                new City{CountryId="Colombia",CityName="Manizales"},
                new City{CountryId="Colombia",CityName="Neiva"},
                new City{CountryId="Colombia",CityName="Palmira"},
                new City{CountryId="Colombia",CityName="Riohacha"},
                new City{CountryId="Colombia",CityName="Sincelejo"},
                new City{CountryId="Colombia",CityName="Popayán"},
                new City{CountryId="Colombia",CityName="Itagüí"},
                new City{CountryId="Colombia",CityName="Floridablanca"},
                new City{CountryId="Colombia",CityName="Envigado"},
                new City{CountryId="Colombia",CityName="Tuluá"},
                new City{CountryId="Colombia",CityName="San Andrés de Tumaco"},
                new City{CountryId="Colombia",CityName="Dosquebradas"},
                new City{CountryId="Colombia",CityName="Apartadó"},
                new City{CountryId="Colombia",CityName="Tunja"},
                new City{CountryId="Colombia",CityName="Girón"},
                new City{CountryId="Colombia",CityName="Uribia"},
                new City{CountryId="Colombia",CityName="Barrancabermeja"},
                new City{CountryId="Colombia",CityName="Florencia"},
                new City{CountryId="Colombia",CityName="Turbo"},
                new City{CountryId="Colombia",CityName="Maicao"},
                new City{CountryId="Colombia",CityName="Piedecuesta"},
                new City{CountryId="Colombia",CityName="Yopal"}
            };
            
            modelBuilder.Entity<Respuesta>().HasKey(r => new { r.PreguntaId, r.RespondenteId });
            modelBuilder.Entity<EncuestaRepondente>().HasKey(r => new { r.EncuestaId, r.RespondenteId });
            modelBuilder.Entity<Categoria>().HasData(categorias);
            modelBuilder.Entity<TipoPregunta>().HasData(tipoPreguntas);
            modelBuilder.Entity<Country>().HasData(Paises);
            modelBuilder.Entity<City>().HasData(Ciudades);

            base.OnModelCreating(modelBuilder);
        }

    }
}
