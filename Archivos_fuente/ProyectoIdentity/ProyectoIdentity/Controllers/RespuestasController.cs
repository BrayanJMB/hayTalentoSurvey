using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;
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


        public async Task<IActionResult> IndexRespuestas(string idSurvey)
        {
            ViewBag.Message = "Login";
            var Model = new ModelSurvey();
            Model.Categorias = ModelSurvey.Categories();
            return View(Model);
        }

        public async Task<IActionResult> RedirectIndexRespuestas()
        {
            ViewBag.Message = "EnvioRedirectRespuestas";
            return View();
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
