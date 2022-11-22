﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoIdentity.Datos;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221122035608_newtables1")]
    partial class newtables1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("NombreCategoria")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Demograficos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Demograficos");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Encuesta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DescripcionEncuesta")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaMaximoPlazo")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreEncuesta")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Encuesta");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.EncuestaCategoria", b =>
                {
                    b.Property<int>("EncuestaId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.HasKey("EncuestaId", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("EncuestaCategoria");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.EncuestaDemografico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdDemografico")
                        .HasColumnType("int");

                    b.Property<int>("IdEncuesta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDemografico");

                    b.HasIndex("IdEncuesta");

                    b.ToTable("EncuestaDemografico");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.EncuestaRepondente", b =>
                {
                    b.Property<int>("EncuestaId")
                        .HasColumnType("int");

                    b.Property<Guid>("RespondenteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaRespuesta")
                        .HasColumnType("datetime2");

                    b.HasKey("EncuestaId", "RespondenteId");

                    b.HasIndex("RespondenteId");

                    b.ToTable("EncuestaRepondente");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Opcion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumeroOpcion")
                        .HasColumnType("int");

                    b.Property<int>("PreguntaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreguntaId");

                    b.ToTable("Opcion");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.OpcionesDemo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DemograficoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DemograficoId");

                    b.ToTable("OpcionesDemo");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Pregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("NombrePregunta")
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<int>("TipoPreguntaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("TipoPreguntaId");

                    b.ToTable("Pregunta");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Respondente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Respondente");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.RespondenteDemografico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DemograficosId")
                        .HasColumnType("int");

                    b.Property<Guid>("RespondenteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Respuesta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DemograficosId");

                    b.HasIndex("RespondenteId");

                    b.ToTable("RespondenteDemografico");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Respuesta", b =>
                {
                    b.Property<int>("PreguntaId")
                        .HasColumnType("int");

                    b.Property<Guid>("RespondenteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DescripcionRespuesta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("PreguntaId", "RespondenteId");

                    b.HasIndex("RespondenteId");

                    b.ToTable("Respuesta");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.TipoPregunta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("NombreTipoPregunta")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TipoPregunta");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Company", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Adress")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PersonFullName")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasDiscriminator().HasValue("Company");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Encuesta", b =>
                {
                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Company", "Company")
                        .WithMany("Encuestas")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.EncuestaCategoria", b =>
                {
                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Categoria", null)
                        .WithMany("EncuestaCategoria")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Encuesta", null)
                        .WithMany("EncuestaCategorias")
                        .HasForeignKey("EncuestaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.EncuestaDemografico", b =>
                {
                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Demograficos", "Demografico")
                        .WithMany("EncuestaDemografico")
                        .HasForeignKey("IdDemografico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Encuesta", "Encuesta")
                        .WithMany()
                        .HasForeignKey("IdEncuesta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Demografico");

                    b.Navigation("Encuesta");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.EncuestaRepondente", b =>
                {
                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Encuesta", null)
                        .WithMany("Versions")
                        .HasForeignKey("EncuestaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Respondente", null)
                        .WithMany("EncuestaRepondente")
                        .HasForeignKey("RespondenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Opcion", b =>
                {
                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Pregunta", "Pregunta")
                        .WithMany("Opciones")
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pregunta");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.OpcionesDemo", b =>
                {
                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Demograficos", "Demograficos")
                        .WithMany("OpcionesDemo")
                        .HasForeignKey("DemograficoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Demograficos");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Pregunta", b =>
                {
                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Categoria", "Categoria")
                        .WithMany("Preguntas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.TipoPregunta", "TipoPregunta")
                        .WithMany("Pregunta")
                        .HasForeignKey("TipoPreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("TipoPregunta");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.RespondenteDemografico", b =>
                {
                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Demograficos", "Demograficos")
                        .WithMany("RespondenteDemograficos")
                        .HasForeignKey("DemograficosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Respondente", "Respondente")
                        .WithMany("RespondenteDemograficos")
                        .HasForeignKey("RespondenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Demograficos");

                    b.Navigation("Respondente");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Respuesta", b =>
                {
                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Pregunta", "Pregunta")
                        .WithMany("Respuestas")
                        .HasForeignKey("PreguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIdentity.Models.ModelsJourney.Respondente", "Respondente")
                        .WithMany("Respuestas")
                        .HasForeignKey("RespondenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pregunta");

                    b.Navigation("Respondente");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Categoria", b =>
                {
                    b.Navigation("EncuestaCategoria");

                    b.Navigation("Preguntas");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Demograficos", b =>
                {
                    b.Navigation("EncuestaDemografico");

                    b.Navigation("OpcionesDemo");

                    b.Navigation("RespondenteDemograficos");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Encuesta", b =>
                {
                    b.Navigation("EncuestaCategorias");

                    b.Navigation("Versions");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Pregunta", b =>
                {
                    b.Navigation("Opciones");

                    b.Navigation("Respuestas");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Respondente", b =>
                {
                    b.Navigation("EncuestaRepondente");

                    b.Navigation("RespondenteDemograficos");

                    b.Navigation("Respuestas");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.TipoPregunta", b =>
                {
                    b.Navigation("Pregunta");
                });

            modelBuilder.Entity("ProyectoIdentity.Models.ModelsJourney.Company", b =>
                {
                    b.Navigation("Encuestas");
                });
#pragma warning restore 612, 618
        }
    }
}
