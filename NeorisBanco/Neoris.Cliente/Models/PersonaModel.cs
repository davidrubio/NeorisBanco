

using System.ComponentModel.DataAnnotations.Schema;

namespace Neoris.Models
{
    public class Persona
    {
        public int Secuencial { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        
        [ForeignKey("Genero")]
        public int SecuencialGenero { get; set; }
        public Genero Genero { get; set; }
    }
}
