using Microsoft.EntityFrameworkCore;
using Neoris.Cliente.Repository;
using Neoris.Cliente.Utils;
using Neoris.Models;

namespace Neoris.Cliente.Manager
{
    public class CuentaManager
    {
        private readonly ApplicationDbContext _context;
        public CuentaManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Cuenta> DameCuentas()
        {
            var cuenta = _context.Cuenta.Where(x => x.EstaActivo)
                .Include(x => x.TipoCuenta)
                .Include(x => x.Cliente)
                .ThenInclude(c => c.Persona)
                .ThenInclude(c => c.Genero).ToList();
            return cuenta;
        }

        public Cuenta DameCuenta(string numeroCuenta)
        {
            var cuenta = _context.Cuenta.Where(x => x.EstaActivo)
                .Include(x => x.TipoCuenta)
                .Include(x => x.Cliente)
                .ThenInclude(c => c.Persona)
                .ThenInclude(c => c.Genero)
                .FirstOrDefault(x => x.NumeroCuenta == numeroCuenta && x.EstaActivo);
            if (cuenta == null)
                throw new Exception("La Cuenta no existe");
            return cuenta;
        }

        public string CreaEditaCuenta(CuentaRequest request)
        {
            Cuenta cuenta = new Cuenta();
            bool esNuevo = false;
            if (request.Secuencial > 0)
            {
                cuenta = _context.Cuenta.Where(x => x.Secuencial == request.Secuencial).FirstOrDefault();
                if (cuenta != null)
                {
                    cuenta.SecuencialTipoCuenta = request.SecuencialTipoCuenta;
                    _context.SaveChanges();
                }
                else
                    esNuevo = true;
            }
            else
                esNuevo = true;


            if (esNuevo)
            {
                var cliente = _context.Cliente.FirstOrDefault(x => x.Persona.Identificacion == request.Identificacion && x.EstaActivo);
                if (cliente == null)
                    throw new Exception("El cliente no existe");

                var totalCuentas = _context.Cuenta.Where(x => x.SecuencialCliente == cliente.Secuencial).Count();

                cuenta = new Cuenta();
                cuenta.SecuencialCliente = cliente.Secuencial;
                cuenta.NumeroCuenta = UtilidadesGenericas.GenerarNumeroCuenta(cliente.Secuencial, totalCuentas);
                cuenta.SecuencialTipoCuenta = request.SecuencialTipoCuenta;
                cuenta.SaldoActual = request.SaldoActual;
                cuenta.SaldoCorte = request.SaldoActual;
                cuenta.EstaActivo = true;
                _context.Cuenta.Add(cuenta);
                _context.SaveChanges();

                Movimiento movimiento = new Movimiento();
                movimiento.SecuencialTipoMovimiento = 3;
                movimiento.SecuencialTipoCanal = request.SecuencialTipoCanal;
                movimiento.SecuencialCuenta = cuenta.Secuencial;
                movimiento.FechaMovimiento = DateTime.Now;
                movimiento.Valor = request.SaldoActual;
                movimiento.Saldo = request.SaldoActual;
                movimiento.Detalle = "Apertura Cuenta";
                movimiento.EstaActivo = true;
                _context.Movimiento.Add(movimiento);
                _context.SaveChanges();

            }
            return cuenta.NumeroCuenta;
        }

        public bool EliminaCuenta(string numeroCuenta)
        {
            var cuenta = _context.Cuenta.FirstOrDefault(x => x.NumeroCuenta.Equals(numeroCuenta) && x.EstaActivo);
            if (cuenta == null)
                throw new Exception("La Cuenta no existe");
            else
            {
                cuenta.EstaActivo = false;
                _context.SaveChanges();
            }
            return true;
        }

    }
}
