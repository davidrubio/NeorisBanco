

using System.ComponentModel.DataAnnotations.Schema;

namespace Neoris.Models
{
    public class Movimiento
    {
        public int Secuencial { get; set; }

        [ForeignKey("Cuenta")]
        public int SecuencialCuenta { get; set; }

        [ForeignKey("TipoMovimiento")]
        public int SecuencialTipoMovimiento { get; set; }

        [ForeignKey("TipoCanal")]
        public int SecuencialTipoCanal { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public string Detalle { get; set; }
        public bool EstaActivo { get; set; }
        public Cuenta Cuenta { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public TipoCanal TipoCanal { get; set; }
    }

    public class MovimientoRequest
    {
        public string NumeroCuenta { get; set; }
        public int SecuencialTipoMovimiento { get; set; }
        public int SecuencialTipoCanal { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public decimal Valor { get; set; }
        public string Detalle { get; set; }
    }

    public class MovimientosReporteRequest
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal Saldo { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public decimal Valor { get; set; }
        public string Detalle { get; set; }
    }

}
