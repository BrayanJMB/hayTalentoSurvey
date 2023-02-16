using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Models.ModelosRespuestas;
using ProyectoIdentity.Models.ModelsJourney;

using System.Security.Cryptography.Xml;


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

        public DbSet<DemograficoPersonal> DemograficoPersonal { get; set; }

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

        public DbSet<RespuestaMadurezcs> RespuestaMadurezcs { get; set; }

        public DbSet<EncuestaRespondenteB> EncuestaRespondenteB { get; set; }

        public DbSet<RespuestaPersonalizada> RespuestaPersonalizada { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Categoria> categorias = new List<Categoria> {
                new Categoria{Id=1,NombreCategoria="Aspectos Demográficos",
                        Descripcion="Diligencie la información de acuerdo con sus datos actuales"
                    },
                new Categoria{Id=2,NombreCategoria="Datos Personales",
                        Descripcion="Diligencia la siguiente información acorde con tu actualidad y la de tu núcleo familiar"
                    },

                    new Categoria{Id=3,NombreCategoria="Beneficios de Calidad de Vida",
                        Descripcion="Aspectos relacionados con las condiciones favorables en la relación laboral y el ambiente de trabajo."
                    },
                    new Categoria{Id=4,NombreCategoria="Beneficios Monetarios y No Monetarios",
                        Descripcion="Paquete de mejoras extralegales que complementan el salario base, pueden ser monetarias o emocionales."
                    },
                    new Categoria{Id=5,NombreCategoria="Beneficios de Desarrollo Personal",
                    Descripcion="Acciones de largo plazo que apuestan por el crecimiento personal, potencializar el talento y transformar la organización."

                    },
                    new Categoria{Id=6,NombreCategoria="Beneficios en Herramientas de Trabajo",
                        Descripcion="Elementos útiles para una adecuada realización de la labor."
                    },
                    new Categoria{Id=7,NombreCategoria="Beneficios/Madurez",
                    Descripcion="Nivel en el que la compañía asimila o integra buenas prácticas relacionadas con la administración de los beneficios"

                    }
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
                new City{CountryId="Colombia",CityName="Yopal"},
                new City{CountryId="Antigua y Barbuda",CityName="Saint John"},
                new City{CountryId="Argentina",CityName="Buenos Aires"},
                new City{CountryId="Bahamas",CityName="Nasáu"},
                new City{CountryId="Barbados",CityName="Bridgetown"},
                new City{CountryId="Belice",CityName="Belmopán"},
                new City{CountryId="Bolivia",CityName="Sucre"},
                new City{CountryId="Brasil",CityName="Brasilia"},
                new City{CountryId="Canadá",CityName="Ottawa"},
                new City{CountryId="Chile",CityName="Santiago"},
                new City{CountryId="Costa Rica",CityName="San José"},
                new City{CountryId="Cuba",CityName="La Habana"},
                new City{CountryId="Dominica",CityName="Roseau"},
                new City{CountryId="Ecuador",CityName="Quito"},
                new City{CountryId="El Salvador",CityName="San Salvador"},
                new City{CountryId="Estados Unidos",CityName="Washington"},
                new City{CountryId="Granada",CityName="Granada"},
                new City{CountryId="Guatemala",CityName="Ciudad de Guatemala"},
                new City{CountryId="Guyana",CityName="Georgetown"},
                new City{CountryId="Haití",CityName="Puerto Príncipe"},
                new City{CountryId="Honduras",CityName="Tegucigalpa"},
                new City{CountryId="Jamaica",CityName="Kingston"},
                new City{CountryId="México",CityName="Ciudad de México"},
                new City{CountryId="Nicaragua",CityName="Managua"},
                new City{CountryId="Panamá",CityName="Ciudad de Panamá"},
                new City{CountryId="Paraguay",CityName="Paraguay"},
                new City{CountryId="Perú",CityName="Lima"},
                new City{CountryId="República Dominicana",CityName="Santo Domingo"},
                new City{CountryId="San Cristóbal y Nieves",CityName="Basseterre"},
                new City{CountryId="Uruguay",CityName="Montevideo"},
                new City{CountryId="Venezuela",CityName="Caracas"}

            };

            modelBuilder.Entity<Categoria>().HasData(categorias);
            modelBuilder.Entity<TipoPregunta>().HasData(tipoPreguntas);
            modelBuilder.Entity<Country>().HasData(Paises);
            modelBuilder.Entity<City>().HasData(Ciudades);

            base.OnModelCreating(modelBuilder);
        }

    }
}
