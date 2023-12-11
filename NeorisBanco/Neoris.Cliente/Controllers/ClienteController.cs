using Azure;
using Microsoft.AspNetCore.Mvc;
using Neoris.Cliente.Manager;
using Neoris.Cliente.Repository;
using Neoris.Cliente.Utils;
using Neoris.Models;

namespace Neoris.Cliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ClienteManager clienteManager;
        public ClienteController(ApplicationDbContext context)
        {
            clienteManager = new ClienteManager(context);
        }

        [HttpGet("dameClientes")]
        public IActionResult DameClientes()
        {
            List<Neoris.Models.Cliente> clientes = new List<Neoris.Models.Cliente>();
            try
            {
                clientes = clienteManager.DameClientes();
                return Ok(UtilidadesGenericas.CrearRespuestaGenerica(clientes, string.Empty));
            }
            catch (Exception e)
            {
                return BadRequest(UtilidadesGenericas.CrearRespuestaGenericaError(clientes, e.Message));
            }
        }

        [HttpGet("dameCliente/{id}")]
        public IActionResult DameCliente(string id)
        {
            Models.Cliente clientes = new Models.Cliente();
            try
            {
                clientes = clienteManager.DameCliente(id);
                return Ok(UtilidadesGenericas.CrearRespuestaGenerica(clientes, string.Empty));
            }
            catch (Exception e)
            {
                return BadRequest(UtilidadesGenericas.CrearRespuestaGenericaError(clientes, e.Message));
            }
        }

        [HttpPost("creaCliente")]
        public IActionResult CreaClientes(CreaClienteRequest request)
        {
            try
            {
                var response = clienteManager.CreaEditaClientes(request);
                return Ok(UtilidadesGenericas.CrearRespuestaGenerica(response, string.Empty));
            }
            catch (Exception e)
            {
                return BadRequest(UtilidadesGenericas.CrearRespuestaGenericaError(false, e.Message));
            }
        }

        [HttpPost("editaCliente")]
        public IActionResult EditaClientes(CreaClienteRequest request)
        {
            try
            {
                var response = clienteManager.CreaEditaClientes(request);
                return Ok(UtilidadesGenericas.CrearRespuestaGenerica(response, string.Empty));
            }
            catch (Exception e)
            {
                return BadRequest(UtilidadesGenericas.CrearRespuestaGenericaError(false, e.Message));
            }
        }

        [HttpDelete("eliminaCliente/{id}")]
        public IActionResult EliminaCliente(string id)
        {
            try
            {
                var response = clienteManager.EliminaCliente(id);
                return Ok(UtilidadesGenericas.CrearRespuestaGenerica(response, string.Empty));
            }
            catch (Exception e)
            {
                return BadRequest(UtilidadesGenericas.CrearRespuestaGenericaError(false, e.Message));
            }
        }
    }
}
