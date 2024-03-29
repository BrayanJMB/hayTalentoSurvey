﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelsJourney
{
    public class Respuesta
    {
        public int Id { get; set; }

        public string? DescripcionRespuesta { get; set; }

        public float? Valor { get; set; }

        public string? RespuestaOpcion { get; set; }

        //llaves Foraneas
        [Display(Name = "Id Persona que Responde")]
        [HiddenInput(DisplayValue = false)]
        [ForeignKey("Respondente")]
        public Guid? RespondenteId { get; set; }
        public Respondente? Respondente { get; set; }
        [Display(Name = "Pregunta")]
        [HiddenInput(DisplayValue = false)]
        [ForeignKey("Pregunta")]
        public int PreguntaId { get; set; }

        public Pregunta? Pregunta { get; set; }
        [ForeignKey("EncuestaRespondenteB")]
        public int? EncuestaRespondenteId { get; set; }

        public EncuestaRespondenteB? EncuestaRespondenteB { get; set; }

    }
}
