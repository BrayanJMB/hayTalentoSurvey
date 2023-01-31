using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Respuesta
    {

        public string? DescripcionRespuesta { get; set; }

        public float? Valor { get; set; }

        //llaves Foraneas
        [Display(Name = "Id Persona que Responde")]
        [HiddenInput(DisplayValue = false)]
        public Guid? RespondenteId { get; set; }
        public Respondente? Respondente { get; set; }
        [Display(Name = "Pregunta")]
        [HiddenInput(DisplayValue = false)]
        public int PreguntaId { get; set; }

        public Pregunta? Pregunta { get; set; }
        [ForeignKey("EncuestaRespondenteB")]
        public int? EncuestaRespondenteId { get; set; }

        public EncuestaRespondenteB? EncuestaRespondenteB { get; set; }

    }
}
