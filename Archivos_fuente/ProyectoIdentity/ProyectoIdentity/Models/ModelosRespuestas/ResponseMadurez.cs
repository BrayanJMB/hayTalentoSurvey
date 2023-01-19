namespace ProyectoIdentity.Models.ModelosRespuestas
{
    public class ResponseMadurez
    {
        public int IdEncuesta { get; set; }
        public int IdPregunta { get; set; }

        public float? ValueRespuesta { get; set; }

        public string? LabelRespuesta { get; set; }

    }
}
