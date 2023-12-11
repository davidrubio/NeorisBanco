namespace Neoris.Cliente.Utils
{
    public class RespuestaModel
    {
        public class RespuestaGenerica
        {
            public DateTime FechaHora { get; set; }
            public string estado { get; set; }
            public string mensaje { get; set; }
            public object resultado { get; set; }

        }
    }
}
