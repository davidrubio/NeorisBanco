using Microsoft.EntityFrameworkCore;
using Neoris.Cliente.Repository;
using Neoris.Cliente.Utils;
using Neoris.Models;

namespace Neoris.Cliente.Manager
{
    public class ReporteManager
    {
        private readonly ApplicationDbContext _context;
        public ReporteManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MovimientosReporteRequest> DamePorRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<MovimientosReporteRequest> listaMovimientos = new List<MovimientosReporteRequest>();
            MovimientosReporteRequest nuevoItem;
            var movimientos = _context.Movimiento
                .Where(x => x.FechaMovimiento >= fechaInicio && x.FechaMovimiento <= fechaFin && x.EstaActivo)
                .Include(x => x.TipoMovimiento)
                .Include(x => x.TipoCanal)
                .Include(x => x.Cuenta)
                .ThenInclude(x => x.TipoCuenta)
                .Include(x => x.Cuenta.Cliente)
                .ThenInclude(x => x.Persona)
                .OrderBy(x => x.Cuenta.NumeroCuenta)
                .ThenBy(x => x.Secuencial)
                .ToList();

            foreach (var item in movimientos)
            {
                nuevoItem = new MovimientosReporteRequest();
                nuevoItem.Identificacion = item.Cuenta.Cliente.Persona.Identificacion;  
                nuevoItem.Nombres = item.Cuenta.Cliente.Persona.Nombres;
                nuevoItem.NumeroCuenta = item.Cuenta.NumeroCuenta;
                nuevoItem.TipoCuenta = item.Cuenta.TipoCuenta.Nombre;
                nuevoItem.Saldo = item.Saldo;
                nuevoItem.TipoMovimiento = item.TipoMovimiento.Nombre;
                nuevoItem.FechaMovimiento = item.FechaMovimiento;
                nuevoItem.Valor = item.Valor;
                nuevoItem.Detalle = item.Detalle;
                listaMovimientos.Add(nuevoItem);
            }
            return listaMovimientos;
        }

    }
}
