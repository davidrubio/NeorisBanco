using static Neoris.Cliente.Utils.RespuestaModel;

namespace Neoris.Cliente.Utils
{
    public class UtilidadesGenericas
    {
        public static RespuestaGenerica CrearRespuestaGenerica(object response, string mensaje)
        {
            RespuestaGenerica respuestaGenerica = new RespuestaGenerica();
            respuestaGenerica.FechaHora = DateTime.Now;
            respuestaGenerica.estado = "OK";
            respuestaGenerica.mensaje = mensaje;
            respuestaGenerica.resultado = response;
            return respuestaGenerica;
        }

        public static RespuestaGenerica CrearRespuestaGenericaError(object response, string mensaje)
        {
            RespuestaGenerica respuestaGenerica = new RespuestaGenerica();
            respuestaGenerica.FechaHora = DateTime.Now;
            respuestaGenerica.estado = "ERROR";
            respuestaGenerica.mensaje = mensaje;
            respuestaGenerica.resultado = response;
            return respuestaGenerica;
        }
    }
}
