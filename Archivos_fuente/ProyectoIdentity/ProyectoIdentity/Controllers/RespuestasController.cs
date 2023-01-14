using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models;
using ProyectoIdentity.Models.ModelsJourney;
using ProyectoIdentity.Models.ModelTemplateJorney;

namespace ProyectoIdentity.Controllers
{
    public class RespuestasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RespuestasController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> IndexRespuestas(int idSurvey)
        {
            ViewBag.Message = "Login";

            var query =
                (from encuesta in _context.Encuesta
                 join encuestaCate in _context.EncuestaCategoria
                 on encuesta.Id equals encuestaCate.EncuestaId
                 where encuesta.Id == idSurvey
                 select new
                 {
                     (from categoria in _context.Categoria
                      select new ModelSurvey
                      {
                          Categorias = (from categoriaPregunta in _context.Categoria
                                        select new Category
                                        {
                                            NombreCategoria = categoriaPregunta.NombreCategoria,
                                            Preguntas = (from pregunta in _context.Pregunta
                                                         where pregunta.EncuestaCategoriaId == categoriaPregunta.Id
                                                         select new Models.ModelTemplateJorney.Pregunta
                                                         {
                                                             NombrePregunta = pregunta.NombrePregunta,
                                                             IdTipo = pregunta.TipoPreguntaId,
                                                             Opciones = (from opciones in _context.Opcion
                                                                         where pregunta.Id == opciones.PreguntaId
                                                                         select new Models.ModelTemplateJorney.Opcion

                                                                         {
                                                                             OpcionName = opciones.Nombre
                                                                         }).ToList()
                                                         }).ToList()
                                        }).ToList()
                      }).FirstOrDefault()
                 }).FirstOrDefault();
            return View(query);
        }

        public async Task<IActionResult> RedirectIndexRespuestas(string idSurvey)
        {

            ViewBag.Message = "EnvioRedirectRespuestas";
            var query = (from encuesta in _context.Encuesta
                         where encuesta.Id == int.Parse(idSurvey)
                         select new Encuesta
                         {
                             NombreEncuesta = encuesta.NombreEncuesta,
                             DescripcionEncuesta = encuesta.DescripcionEncuesta
                         }).FirstOrDefault();
            return View(query);
        }

        public async Task<IActionResult> EnvioIndexRespuestas()
        {
            ViewBag.Message = "Login";
            return View();
        }


        ////////////Encuesta Madurez//////////////////////////

        public async Task<IActionResult> IndexRespuestasMadurez()
        {
            ViewBag.Message = "Login";
            var Model = new ModelSurvey();
            Model.Categorias = ModelSurvey.CategoriesMadurez();
            return View(Model);
        }

        public async Task<IActionResult> RedirectIndexRespuestasMadurez()
        {
            ViewBag.Message = "EnvioRedirectRespuestasMadurez";
            return View();
        }

        public async Task<IActionResult> EnvioIndexRespuestasMadurez()
        {
            ViewBag.Message = "Login";
            return View();
        }
    }
}
