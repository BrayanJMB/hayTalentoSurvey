using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class NewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaName);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    PersonFullName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnit",
                columns: table => new
                {
                    NameBusinnes = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnit", x => x.NameBusinnes);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryName);
                });

            migrationBuilder.CreateTable(
                name: "Demograficos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroDemografico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demograficos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPregunta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoPregunta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPregunta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Encuesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEncuesta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DescripcionEncuesta = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaDeCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaMaximoPlazo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encuesta_AspNetUsers_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Respondente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BussinesUnitId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BusinessUnitNameBusinnes = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respondente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respondente_Area_AreaName",
                        column: x => x.AreaName,
                        principalTable: "Area",
                        principalColumn: "AreaName");
                    table.ForeignKey(
                        name: "FK_Respondente_BusinessUnit_BusinessUnitNameBusinnes",
                        column: x => x.BusinessUnitNameBusinnes,
                        principalTable: "BusinessUnit",
                        principalColumn: "NameBusinnes");
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CountryId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityName);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryName");
                });

            migrationBuilder.CreateTable(
                name: "OpcionesDemo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DemograficoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcionesDemo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcionesDemo_Demograficos_DemograficoId",
                        column: x => x.DemograficoId,
                        principalTable: "Demograficos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaArea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncuestaId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncuestaArea_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "AreaName");
                    table.ForeignKey(
                        name: "FK_EncuestaArea_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaBussines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncuestaId = table.Column<int>(type: "int", nullable: false),
                    BusinessUnitId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaBussines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncuestaBussines_BusinessUnit_BusinessUnitId",
                        column: x => x.BusinessUnitId,
                        principalTable: "BusinessUnit",
                        principalColumn: "NameBusinnes");
                    table.ForeignKey(
                        name: "FK_EncuestaBussines_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    EncuestaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaCategoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncuestaCategoria_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuestaCategoria_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaDemografico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemograficoId = table.Column<int>(type: "int", nullable: false),
                    EncuestaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaDemografico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncuestaDemografico_Demograficos_DemograficoId",
                        column: x => x.DemograficoId,
                        principalTable: "Demograficos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuestaDemografico_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemograficoPersonal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parentesco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelEducativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DependenciaEconomica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespondenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemograficoPersonal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemograficoPersonal_Respondente_RespondenteId",
                        column: x => x.RespondenteId,
                        principalTable: "Respondente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EncuestaRepondente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncuestaId = table.Column<int>(type: "int", nullable: false),
                    RespondenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FechaRespuesta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PonderadoRespuesta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaRepondente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncuestaRepondente_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuestaRepondente_Respondente_RespondenteId",
                        column: x => x.RespondenteId,
                        principalTable: "Respondente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EncuestaRespondenteB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncuestaId = table.Column<int>(type: "int", nullable: false),
                    RespondenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FechaRespuesta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaRespondenteB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncuestaRespondenteB_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuestaRespondenteB_Respondente_RespondenteId",
                        column: x => x.RespondenteId,
                        principalTable: "Respondente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pregunta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePregunta = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DescripcionPregunta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroPregunta = table.Column<int>(type: "int", nullable: false),
                    TipoPreguntaId = table.Column<int>(type: "int", nullable: false),
                    EncuestaCategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregunta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pregunta_EncuestaCategoria_EncuestaCategoriaId",
                        column: x => x.EncuestaCategoriaId,
                        principalTable: "EncuestaCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pregunta_TipoPregunta_TipoPreguntaId",
                        column: x => x.TipoPreguntaId,
                        principalTable: "TipoPregunta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespuestaPersonalizada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPregunta = table.Column<int>(type: "int", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beneficio = table.Column<bool>(type: "bit", nullable: false),
                    Atractivo = table.Column<float>(type: "real", nullable: false),
                    Funcionamiento = table.Column<float>(type: "real", nullable: false),
                    EncuestaResponcenteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaPersonalizada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespuestaPersonalizada_EncuestaRespondenteB_EncuestaResponcenteId",
                        column: x => x.EncuestaResponcenteId,
                        principalTable: "EncuestaRespondenteB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Opcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NumeroOpcion = table.Column<int>(type: "int", nullable: false),
                    ValorOpcion = table.Column<float>(type: "real", nullable: false),
                    PreguntaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opcion_Pregunta_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Pregunta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuesta",
                columns: table => new
                {
                    RespondenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PreguntaId = table.Column<int>(type: "int", nullable: false),
                    DescripcionRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<float>(type: "real", nullable: true),
                    EncuestaRespondenteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuesta", x => new { x.PreguntaId, x.RespondenteId });
                    table.ForeignKey(
                        name: "FK_Respuesta_EncuestaRespondenteB_EncuestaRespondenteId",
                        column: x => x.EncuestaRespondenteId,
                        principalTable: "EncuestaRespondenteB",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Respuesta_Pregunta_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Pregunta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Respuesta_Respondente_RespondenteId",
                        column: x => x.RespondenteId,
                        principalTable: "Respondente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespuestaMadurezcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<float>(type: "real", nullable: true),
                    PreguntaId = table.Column<int>(type: "int", nullable: false),
                    EncuestaRespondenteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaMadurezcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespuestaMadurezcs_EncuestaRepondente_EncuestaRespondenteID",
                        column: x => x.EncuestaRespondenteID,
                        principalTable: "EncuestaRepondente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespuestaMadurezcs_Pregunta_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Pregunta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Descripcion", "NombreCategoria" },
                values: new object[,]
                {
                    { 1, "Diligencie la información de acuerdo con sus datos actuales", "Aspectos Demográficos" },
                    { 2, "Diligencia la siguiente información acorde con tu actualidad y la de tu núcleo familiar", "Datos Personales" },
                    { 3, "Aspectos relacionados con las condiciones favorables en la relación laboral y el ambiente de trabajo.", "Beneficios de Calidad de Vida" },
                    { 4, "Paquete de mejoras extralegales que complementan el salario base, pueden ser monetarias o emocionales.", "Beneficios Monetarios y No Monetarios" },
                    { 5, "Acciones de largo plazo que apuestan por el crecimiento personal, potencializar el talento y transformar la organización.", "Beneficios de Desarrollo Personal" },
                    { 6, "Elementos útiles para una adecuada realización de la labor.", "Beneficios en Herramientas de Trabajo" },
                    { 7, "Nivel en el que la compañía asimila o integra buenas prácticas relacionadas con la administración de los beneficios", "Beneficios/Madurez" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                column: "CountryName",
                values: new object[]
                {
                    "Antigua y Barbuda",
                    "Argentina",
                    "Bahamas",
                    "Barbados",
                    "Belice",
                    "Bolivia",
                    "Brasil",
                    "Canadá",
                    "Chile",
                    "Colombia",
                    "Costa Rica",
                    "Cuba",
                    "Dominica",
                    "Ecuador",
                    "El Salvador",
                    "Estados Unidos",
                    "Granada",
                    "Guatemala",
                    "Guyana",
                    "Haití",
                    "Honduras",
                    "Jamaica",
                    "México",
                    "Nicaragua",
                    "Panamá",
                    "Paraguay",
                    "Perú",
                    "República Dominicana",
                    "San Cristóbal y Nieves",
                    "San Vicente y las Granadinas",
                    "Santa Lucía",
                    "Surinam",
                    "Trinidad y Tobago",
                    "Uruguay",
                    "Venezuela"
                });

            migrationBuilder.InsertData(
                table: "TipoPregunta",
                columns: new[] { "Id", "Descripcion", "NombreTipoPregunta" },
                values: new object[,]
                {
                    { 1, null, "Respuesta Unica" },
                    { 2, null, "Likkert" },
                    { 3, null, "Seleccion Multiple" },
                    { 4, null, "Valoracion Multiple" },
                    { 5, null, "Abierta" },
                    { 6, null, "Multiple Likkert" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityName", "CountryId" },
                values: new object[,]
                {
                    { "Apartadó", "Colombia" },
                    { "Barrancabermeja", "Colombia" },
                    { "Barranquilla", "Colombia" },
                    { "Basseterre", "San Cristóbal y Nieves" },
                    { "Bello", "Colombia" },
                    { "Belmopán", "Belice" },
                    { "Bogotá", "Colombia" },
                    { "Brasilia", "Brasil" },
                    { "Bridgetown", "Barbados" },
                    { "Bucaramanga", "Colombia" },
                    { "Buenaventura", "Colombia" },
                    { "Buenos Aires", "Argentina" },
                    { "Cali", "Colombia" },
                    { "Caracas", "Venezuela" },
                    { "Cartagena", "Colombia" },
                    { "Ciudad de Guatemala", "Guatemala" },
                    { "Ciudad de México", "México" },
                    { "Ciudad de Panamá", "Panamá" },
                    { "Cúcuta", "Colombia" },
                    { "Dosquebradas", "Colombia" },
                    { "Envigado", "Colombia" },
                    { "Florencia", "Colombia" },
                    { "Floridablanca", "Colombia" },
                    { "Georgetown", "Guyana" },
                    { "Girón", "Colombia" },
                    { "Granada", "Granada" },
                    { "Ibagué", "Colombia" },
                    { "Itagüí", "Colombia" },
                    { "Kingston", "Jamaica" },
                    { "La Habana", "Cuba" },
                    { "Lima", "Perú" },
                    { "Maicao", "Colombia" },
                    { "Managua", "Nicaragua" },
                    { "Manizales", "Colombia" },
                    { "Medellín", "Colombia" },
                    { "Montería", "Colombia" },
                    { "Montevideo", "Uruguay" },
                    { "Nasáu", "Bahamas" },
                    { "Neiva", "Colombia" },
                    { "Ottawa", "Canadá" },
                    { "Palmira", "Colombia" },
                    { "Paraguay", "Paraguay" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityName", "CountryId" },
                values: new object[,]
                {
                    { "Pasto", "Colombia" },
                    { "Pereira", "Colombia" },
                    { "Piedecuesta", "Colombia" },
                    { "Popayán", "Colombia" },
                    { "Puerto Príncipe", "Haití" },
                    { "Quito", "Ecuador" },
                    { "Riohacha", "Colombia" },
                    { "Roseau", "Dominica" },
                    { "Saint John", "Antigua y Barbuda" },
                    { "San Andrés de Tumaco", "Colombia" },
                    { "San José", "Costa Rica" },
                    { "San Salvador", "El Salvador" },
                    { "Santa Marta", "Colombia" },
                    { "Santiago", "Chile" },
                    { "Santo Domingo", "República Dominicana" },
                    { "Sincelejo", "Colombia" },
                    { "Soacha", "Colombia" },
                    { "Soledad", "Colombia" },
                    { "Sucre", "Bolivia" },
                    { "Tegucigalpa", "Honduras" },
                    { "Tuluá", "Colombia" },
                    { "Tunja", "Colombia" },
                    { "Turbo", "Colombia" },
                    { "Uribia", "Colombia" },
                    { "Valledupar", "Colombia" },
                    { "Villavicencio", "Colombia" },
                    { "Washington", "Estados Unidos" },
                    { "Yopal", "Colombia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DemograficoPersonal_RespondenteId",
                table: "DemograficoPersonal",
                column: "RespondenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Encuesta_CompanyId",
                table: "Encuesta",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaArea_AreaId",
                table: "EncuestaArea",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaArea_EncuestaId",
                table: "EncuestaArea",
                column: "EncuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaBussines_BusinessUnitId",
                table: "EncuestaBussines",
                column: "BusinessUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaBussines_EncuestaId",
                table: "EncuestaBussines",
                column: "EncuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaCategoria_CategoriaId",
                table: "EncuestaCategoria",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaCategoria_EncuestaId",
                table: "EncuestaCategoria",
                column: "EncuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaDemografico_DemograficoId",
                table: "EncuestaDemografico",
                column: "DemograficoId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaDemografico_EncuestaId",
                table: "EncuestaDemografico",
                column: "EncuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaRepondente_EncuestaId",
                table: "EncuestaRepondente",
                column: "EncuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaRepondente_RespondenteId",
                table: "EncuestaRepondente",
                column: "RespondenteId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaRespondenteB_EncuestaId",
                table: "EncuestaRespondenteB",
                column: "EncuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaRespondenteB_RespondenteId",
                table: "EncuestaRespondenteB",
                column: "RespondenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Opcion_PreguntaId",
                table: "Opcion",
                column: "PreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_OpcionesDemo_DemograficoId",
                table: "OpcionesDemo",
                column: "DemograficoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_EncuestaCategoriaId",
                table: "Pregunta",
                column: "EncuestaCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_TipoPreguntaId",
                table: "Pregunta",
                column: "TipoPreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Respondente_AreaName",
                table: "Respondente",
                column: "AreaName");

            migrationBuilder.CreateIndex(
                name: "IX_Respondente_BusinessUnitNameBusinnes",
                table: "Respondente",
                column: "BusinessUnitNameBusinnes");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_EncuestaRespondenteId",
                table: "Respuesta",
                column: "EncuestaRespondenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_RespondenteId",
                table: "Respuesta",
                column: "RespondenteId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaMadurezcs_EncuestaRespondenteID",
                table: "RespuestaMadurezcs",
                column: "EncuestaRespondenteID");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaMadurezcs_PreguntaId",
                table: "RespuestaMadurezcs",
                column: "PreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaPersonalizada_EncuestaResponcenteId",
                table: "RespuestaPersonalizada",
                column: "EncuestaResponcenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "DemograficoPersonal");

            migrationBuilder.DropTable(
                name: "EncuestaArea");

            migrationBuilder.DropTable(
                name: "EncuestaBussines");

            migrationBuilder.DropTable(
                name: "EncuestaDemografico");

            migrationBuilder.DropTable(
                name: "Opcion");

            migrationBuilder.DropTable(
                name: "OpcionesDemo");

            migrationBuilder.DropTable(
                name: "Respuesta");

            migrationBuilder.DropTable(
                name: "RespuestaMadurezcs");

            migrationBuilder.DropTable(
                name: "RespuestaPersonalizada");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Demograficos");

            migrationBuilder.DropTable(
                name: "EncuestaRepondente");

            migrationBuilder.DropTable(
                name: "Pregunta");

            migrationBuilder.DropTable(
                name: "EncuestaRespondenteB");

            migrationBuilder.DropTable(
                name: "EncuestaCategoria");

            migrationBuilder.DropTable(
                name: "TipoPregunta");

            migrationBuilder.DropTable(
                name: "Respondente");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Encuesta");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "BusinessUnit");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
