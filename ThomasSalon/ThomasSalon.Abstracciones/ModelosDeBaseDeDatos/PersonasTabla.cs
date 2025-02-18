using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    public class PersonasTabla
    {
        [Key]
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string Identificacion { get; set; }
    }
}
