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

        [Required(ErrorMessage = "El teléfono es requerido.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El número de teléfono debe tener exactamente 8 dígitos.")]

        [Required(ErrorMessage = "La propiedad Telefono es requerida")]
        [Phone]

        public string Telefono { get; set; }

        [Required(ErrorMessage = "La propiedad Genero es requerida")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "La propiedad Direccion es requerida")]
        [StringLength(20, ErrorMessage = "La direccion no debe exceder los 20 caracteres.")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "La propiedad Edad es requerida")]
        [Range(15, 100, ErrorMessage = "Edad debe estar entre 15 y 100 años")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "La propiedad Identificacion es requerida")]
        [MaxLength(8)]
        [MinLength(8)]
        public string Identificacion { get; set; }
    }
}
