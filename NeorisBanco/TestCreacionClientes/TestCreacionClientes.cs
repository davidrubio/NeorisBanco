using Microsoft.AspNetCore.Mvc;
using Neoris.Cliente.Controllers;
using Neoris.Cliente.Repository;
using Neoris.Models;
using Xunit.Sdk;

namespace TestCreacionClientes
{

    [TestClass]
    public class TestCreacionClientes
    {
        private ApplicationDbContext context;

        [TestMethod]
        public void TestCreaClienteExitoso()
        {
            CreaClienteRequest request = new CreaClienteRequest();
            ClienteController clienteController = new ClienteController(context);
            request.Nombres = "Prueba Nombre";
            request.Identificacion = "1234567890";
            request.SecuencialGenero = 1;
            request.Edad = 1;
            request.Direccion = "Conocoto";
            request.Telefono = "0987738051";
            var response = clienteController.CreaClientes(request);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public void TestCreaClienteError()
        {
            CreaClienteRequest request = new CreaClienteRequest();
            ClienteController clienteController = new ClienteController(context);
            var response = clienteController.CreaClientes(request);
            Assert.IsInstanceOfType(response, typeof(BadRequestObjectResult));
        }
    }
}