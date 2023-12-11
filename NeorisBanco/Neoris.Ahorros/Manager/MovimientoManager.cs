using Neoris.Cliente.Repository;
using Neoris.Cliente.Utils;
using Neoris.Models;

namespace Neoris.Cliente.Manager
{
    public class MovimientoManager
    {
        private readonly ApplicationDbContext _context;
        public MovimientoManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public string CreaMovimientoTransaccion(MovimientoRequest request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int debito = UtilidadesGenericas.Debito;
                    int credito = UtilidadesGenericas.Credito;

                    var cuenta = _context.Cuenta.FirstOrDefault(x => x.NumeroCuenta.Equals(request.NumeroCuenta) && x.EstaActivo);
                    if (cuenta == null)
                        throw new Exception("La Cuenta no existe");

                    if (request.SecuencialTipoMovimiento == debito && cuenta.SaldoActual < request.Valor)
                        throw new Exception("Saldo no disponible");

                    Movimiento movimiento = new Movimiento();
                    movimiento.SecuencialTipoMovimiento = request.SecuencialTipoMovimiento;
                    movimiento.SecuencialTipoCanal = request.SecuencialTipoCanal;
                    movimiento.SecuencialCuenta = cuenta.Secuencial;
                    movimiento.FechaMovimiento = DateTime.Now;
                    movimiento.Valor = request.Valor;
                    if (request.SecuencialTipoMovimiento == debito)
                    {
                        movimiento.Saldo = cuenta.SaldoActual - request.Valor;
                        cuenta.SaldoActual = movimiento.Saldo;
                    }
                    else if (request.SecuencialTipoMovimiento == credito)
                    {
                        movimiento.Saldo = cuenta.SaldoActual + request.Valor;
                        cuenta.SaldoActual = movimiento.Saldo;
                    }
                    else
                        throw new Exception("Tipo de movimiento invalido");

                    movimiento.Detalle = request.Detalle;
                    movimiento.EstaActivo = true;
                    _context.Movimiento.Add(movimiento);
                    _context.SaveChanges();

                    return "Transaccion finalizada con exito";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

    }
}
