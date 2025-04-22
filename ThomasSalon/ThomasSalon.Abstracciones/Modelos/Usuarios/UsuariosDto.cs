using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Usuarios
{
    public class UsuariosDto
    {

        public string Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Rol { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "La edad es requerida.")]
        [Range(15, int.MaxValue, ErrorMessage = "La edad debe ser mayor a 15.")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "La propiedad Identificacion es requerida")]
        [MaxLength(9)]
        [MinLength(9)]
        public string Identificacion { get; set; }

        [Display(Name = "Estado", Description = "Estado del Servicio")]
        [Required]
        public int IdEstado { get; set; }


        public int? IdSucursal { get; set; }

        public int IdPersona { get; set; }
        [Required]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener exactamente 8 dígitos.")]
        public string Telefono { get; set; }


        [Display(Name = "Estado", Description = "Estado")]
        public string NombreEstado { get; set; }
        [Display(Name = "Rol", Description = "Rol")]

        public string NombreRol { get; set; }
    }
}

