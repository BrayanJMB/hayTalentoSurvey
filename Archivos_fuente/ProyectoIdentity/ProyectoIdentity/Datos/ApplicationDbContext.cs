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
        public DbSet<FechaRespuesta> FechaRespuesta { get; set; }
        public DbSet<Opcion> Opcion { get; set; }
        public DbSet<Pregunta> Pregunta { get; set; }

        public DbSet<Respondente> Respondente { get; set; }
        public DbSet<Respuesta> Respuesta { get; set; }
        public DbSet<TipoPregunta> TipoPregunta { get; set; }
        public DbSet<VersionEncuesta> VersionEncuesta { get; set; }
        public DbSet<Company> Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Respuesta>().HasKey(r => new { r.PreguntaId, r. RespondenteId});

        }

        }
    }
