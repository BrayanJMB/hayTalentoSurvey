using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Models;
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

        public DbSet<Respondente> Respondente { get; set; }
        public DbSet<Respuesta> Respuesta { get; set; }
        public DbSet<TipoPregunta> TipoPregunta { get; set; }
        public DbSet<EncuestaRepondente> EncuestaRepondente { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<RespondenteDemografico> RespondenteDemografico { get; set; }
        public DbSet<OpcionesDemo> OpcionesDemo { get; set; }
        public DbSet<EncuestaDemografico> EncuestaDemografico { get; set; }
        public DbSet<Demograficos> Demograficos { get; set; }

        List<Categoria> categorias = new List<Categoria> {
                    new Categoria{Id=1,NombreCategoria="Beneficios de Calidad de Vida" },
                    new Categoria{Id=2,NombreCategoria="Beneficios Monetarios y No Monetarios" },
                    new Categoria{Id=3,NombreCategoria="Beneficios de Desarrollo Personal" },
                    new Categoria{Id=4,NombreCategoria="Beneficios en Herramientas de Trabajo" },
                    new Categoria{Id=5,NombreCategoria="Beneficios/Madurez" }
        };
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Respuesta>().HasKey(r => new { r.PreguntaId, r. RespondenteId});
            modelBuilder.Entity<EncuestaRepondente>().HasKey(r => new { r.EncuestaId, r.RespondenteId });
            modelBuilder.Entity<EncuestaCategoria>().HasKey(c=> new { c.EncuestaId, c.CategoriaId });
        }

        }
    }
