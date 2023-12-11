using Microsoft.AspNetCore.Mvc;
using Neoris.Cliente.Manager;
using Neoris.Cliente.Repository;
using Neoris.Cliente.Utils;
using Neoris.Models;

namespace Neoris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private CuentaManager cuentaManager;
        public CuentaController(ApplicationDbContext context)
        {
            cuentaManager = new CuentaManager(context);
        }

        [HttpGet("dameCuentas")]
        public IActionResult DameCuentas()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            try
            {
                cuentas = cuentaManager.DameCuentas();
                return Ok(UtilidadesGenericas.CrearRespuestaGenerica(cuentas, string.Empty));
            }
            catch (Exception e)
            {
                return Ok(UtilidadesGenericas.CrearRespuestaGenericaError(cuentas, e.Message));
            }
        }

        [HttpGet("dameCuenta/{id}")]
        public IActionResult DameCuenta(string id)
        {
            Cuenta cuenta = new Cuenta();
            try
            {
                cuenta = cuentaManager.DameCuenta(id);
                return Ok(UtilidadesGenericas.CrearRespuestaGenerica(cuenta, string.Empty));
            }
            catch (Exception e)
            {
                return Ok(UtilidadesGenericas.CrearRespuestaGenericaError(cuenta, e.Message));
            }
        }

        [HttpPost("creaCuenta")]
        public IActionResult CreaCuenta(CuentaRequest request)
        {
            try
            {
                var response = cuentaManager.CreaEditaCuenta(request);
                return Ok(UtilidadesGenericas.CrearRespuestaGenerica(response, string.Empty));
            }
            catch (Exception e)
            {
                return Ok(UtilidadesGenericas.CrearRespuestaGenericaError(false, e.Message));
            }
        }

        [HttpPost("editaCuenta")]
        public IActionResult EditaCuenta(CuentaRequest request)
        {
            try
            {
                var response = cuentaManager.CreaEditaCuenta(request);
                return Ok(UtilidadesGenericas.CrearRespuestaGenerica(response, string.Empty));
            }
            catch (Exception e)
            {
                return Ok(UtilidadesGenericas.CrearRespuestaGenericaError(false, e.Message));
            }
        }

        [HttpDelete("eliminaCuenta/{id}")]
        public IActionResult EliminaCuenta(string id)
        {
            try
            {
                var response = cuentaManager.EliminaCuenta(id);
                return Ok(UtilidadesGenericas.CrearRespuestaGenerica(response, string.Empty));
            }
            catch (Exception e)
            {
                return Ok(UtilidadesGenericas.CrearRespuestaGenericaError(false, e.Message));
            }
        }
    }
}
