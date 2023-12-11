using Microsoft.AspNetCore.Mvc;
using Neoris.Cliente.Manager;
using Neoris.Cliente.Repository;
using Neoris.Cliente.Utils;

namespace Neoris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private ReporteManager reporteManager;
        public ReporteController(ApplicationDbContext context)
        {
            reporteManager = new ReporteManager(context);
        }

        [HttpGet("porRangoFechas")]
        public IActionResult CreaMovimientoTransaccion([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin)
        {
            try
            {
                var response = reporteManager.DamePorRangoFechas(fechaInicio, fechaFin);
                return Ok(UtilidadesGenericas.CrearRespuestaGenerica(response, string.Empty));
            }
            catch (Exception e)
            {
                return Ok(UtilidadesGenericas.CrearRespuestaGenericaError(false, e.Message));
            }
        }
    }
}
