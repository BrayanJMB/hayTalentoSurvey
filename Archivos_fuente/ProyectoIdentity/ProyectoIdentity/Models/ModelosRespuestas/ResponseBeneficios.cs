﻿using ProyectoIdentity.Models.ModelsJourney;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIdentity.Models.ModelosRespuestas
{
    
    public class RespuestasConvalor
    {
        public int IdPregunta { get; set; }
        public string Opcion { get; set; }
        public string? ValorSeleccionado { get; set; }

        public float? Valor { get; set; }
    }


    public class RespuestasDeCheck {
        public int IdPregunta { get; set; }

        public string labelRespuesta { get; set; }  
    }

    public class RespuestaPersonalizada {
        public int Id { get; set; }
        public int IdPregunta { get; set; }

        public string Concepto { get; set; }

        public bool Beneficio { get; set; }

        public string Atractivo { get; set; }

        public string Funcionamiento { get; set; }
        [ForeignKey("EncuestaRespondenteB")]
        public int? EncuestaResponcenteId { get; set; }
        public EncuestaRespondenteB? EncuestaRespondenteB { get; set; }

    }

}
