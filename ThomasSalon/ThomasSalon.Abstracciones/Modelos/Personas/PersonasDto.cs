using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Personas
{
    public class PersonasDto
    {
        [Key]
        public int IdPersona { get; set; }
        [Required(ErrorMessage = "La propiedad Nombre es requerida")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La propiedad Telefono es requerida")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "La propiedad Genero es requerida")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "La propiedad Direccion es requerida")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "La propiedad Edad es requerida")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "La propiedad Identificacion es requerida")]
        public string Identificacion { get; set; }
    }
}
