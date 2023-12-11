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
}
