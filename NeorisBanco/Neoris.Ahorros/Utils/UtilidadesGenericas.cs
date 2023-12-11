using static Neoris.Cliente.Utils.RespuestaModel;

namespace Neoris.Cliente.Utils
{
    public class UtilidadesGenericas
    {
        public const int Debito = 1;
        public const int Credito = 2;
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

        public static string GenerarNumeroCuenta(int secuencialCliente, int numCuentas)
        {
            return DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + numCuentas + "" + secuencialCliente;
        }
    }
}
