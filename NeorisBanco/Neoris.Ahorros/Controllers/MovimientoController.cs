using Microsoft.AspNetCore.Mvc;
using Neoris.Cliente.Manager;
using Neoris.Cliente.Repository;
using Neoris.Cliente.Utils;
using Neoris.Models;

namespace Neoris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private MovimientoManager movimientoManager;
        public MovimientoController(ApplicationDbContext context)
        {
            movimientoManager = new MovimientoManager(context);
        }

        [HttpPost("creaMovimientoTransaccion")]
        public IActionResult CreaMovimientoTransaccion(MovimientoRequest request)
        {
            try
            {
                var response = movimientoManager.CreaMovimientoTransaccion(request);
                return Ok(UtilidadesGenericas.CrearRespuestaGenerica(response, string.Empty));
            }
            catch (Exception e)
            {
                return Ok(UtilidadesGenericas.CrearRespuestaGenericaError(false, e.Message));
            }
        }
    }
}
