namespace ProyectoIdentity.Models.ModelosRespuestas
{
    
    public class RespuestasConvalor
    {
        public int IdPregunta { get; set; }
        public string Opcion { get; set; }

        public string Valor { get; set; }
    }


    public class RespuestasDeCheck {
        public int IdPregunta { get; set; }

        public string labelRespuesta { get; set; }  
    }

    public class RespuestaPersonalizada {
        public int IdPregunta { get; set; }

        public string Concepto { get; set; }

        public bool Beneficio { get; set; }

        public float Atractivo { get; set; }

        public float Funcionamiento { get; set; }

    }

}
