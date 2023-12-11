using Microsoft.EntityFrameworkCore;
using Neoris.Cliente.Repository;
using Neoris.Models;

namespace Neoris.Cliente.Manager
{
    public class ClienteManager
    {
        private readonly ApplicationDbContext _context;
        public ClienteManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Neoris.Models.Cliente> DameClientes()
        {
            var cliente = _context.Cliente.Where(x => x.EstaActivo).Include(x => x.Persona).ThenInclude(c => c.Genero).ToList();
            return cliente;
        }

        public Models.Cliente DameCliente(string identificacion)
        {
            var cliente = _context.Cliente.Include(x => x.Persona).ThenInclude(c => c.Genero).FirstOrDefault(x => x.Persona.Identificacion == identificacion && x.EstaActivo);
            if (cliente == null)
                throw new Exception("El cliente no existe");
            return cliente;
        }

        public bool CreaEditaClientes(CreaClienteRequest request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Persona persona = new Persona();
                    bool esNuevo = false;
                    if (request.Secuencial > 0)
                    {
                        persona = _context.Persona.Where(x => x.Secuencial == request.Secuencial).FirstOrDefault();
                        if (persona != null)
                        {
                            persona.Nombres = request.Nombres;
                            persona.SecuencialGenero = request.SecuencialGenero;
                            persona.Edad = request.Edad;
                            persona.Identificacion = request.Identificacion;
                            persona.Direccion = request.Direccion;
                            persona.Telefono = request.Telefono;
                            _context.SaveChanges();
                            Models.Cliente cli = _context.Cliente.Where(x => x.SecuencialPersona == persona.Secuencial).FirstOrDefault();
                            if (cli != null)
                            {
                                cli.Clave = request.Clave;
                                _context.SaveChanges();
                            }
                        }
                        else
                            esNuevo = true;
                    }
                    else
                        esNuevo = true;


                    if (esNuevo)
                    {
                        persona = new Persona();
                        persona.Nombres = request.Nombres;
                        persona.SecuencialGenero = request.SecuencialGenero;
                        persona.Edad = request.Edad;
                        persona.Identificacion = request.Identificacion;
                        persona.Direccion = request.Direccion;
                        persona.Telefono = request.Telefono;
                        _context.Persona.Add(persona);
                        _context.SaveChanges();

                        if (persona.Secuencial != 0)
                        {
                            Models.Cliente cliente = new Models.Cliente();
                            cliente.SecuencialPersona = persona.Secuencial;
                            cliente.Clave = request.Clave;
                            cliente.EstaActivo = true;
                            _context.Cliente.Add(cliente);
                            _context.SaveChanges();
                        }
                        else
                            return false;
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback(); 
                    throw ;
                }
                return true;
            }
        }

        public bool EliminaCliente(string identificacion)
        {
            var cliente = _context.Cliente.Include(x => x.Persona).ThenInclude(c => c.Genero).ToList().FirstOrDefault(x => x.Persona.Identificacion == identificacion && x.EstaActivo);
            if (cliente == null)
                throw new Exception("El cliente no existe");
            else
            {
                cliente.EstaActivo = false;
                _context.SaveChanges();
            }
            return true;
        }



    }
}
