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
        [Display(Name = "Id Usuario", Description = "Id Usuario")]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} tiene que ser {2} caracteres de largo", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son similares")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public string Rol { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Género")]
        public string Genero { get; set; } 

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required]
        [Range(0, 120, ErrorMessage = "Ingrese una edad válida.")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int IdEstado { get; set; }

        [Display(Name = "Sucursal")]
        public int? IdSucursal { get; set; }

        [Display(Name = "Telefono")]
        public string PhoneNumber { get; set; }

        public string NombreEstado { get; set; }

        public string NombreRol { get; set; } 
    }
}

