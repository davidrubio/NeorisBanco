using System.ComponentModel.DataAnnotations.Schema;

namespace Neoris.Models
{
    public class Cuenta
    {
        public int Secuencial { get; set; }

        [ForeignKey("Cliente")]
        public int SecuencialCliente { get; set; }
        public string NumeroCuenta { get; set; }
        
        [ForeignKey("TipoCuenta")]
        public int SecuencialTipoCuenta { get; set; }
        public decimal SaldoCorte { get; set; }
        public decimal SaldoActual { get; set; }
        public bool EstaActivo { get; set; }
        public Cliente Cliente { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
    }

    public class CuentaRequest
    {
        public int Secuencial { get; set; }
        public string Identificacion { get; set; }
        public int SecuencialTipoCuenta { get; set; }
        public decimal SaldoActual { get; set; }
        public int SecuencialTipoCanal { get; set; }
        public bool EstaActivo { get; set; }
    }

    public class CuentaResponse
    {
        public string NumeroCuenta { get; set; }
    }


}
