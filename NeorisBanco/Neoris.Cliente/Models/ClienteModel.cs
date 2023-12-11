using System.ComponentModel.DataAnnotations.Schema;

namespace Neoris.Models
{
    public class Cliente
    {
        public int Secuencial { get; set; }
       
        [ForeignKey("Persona")]
        public int SecuencialPersona { get; set; }
        public string Clave { get; set; }
        public bool EstaActivo { get; set; }
        public Persona Persona { get; set; }
    }

    public class CreaClienteRequest
    {
        public int Secuencial { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int SecuencialGenero { get; set; }
        public string Clave { get; set; }
    }
}
