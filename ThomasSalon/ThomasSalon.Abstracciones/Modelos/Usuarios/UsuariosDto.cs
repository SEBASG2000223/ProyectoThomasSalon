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

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Rol { get; set; }

        public string Nombre { get; set; }

        public string Genero { get; set; }

        public string Direccion { get; set; }

        public int Edad { get; set; }

        public string Identificacion { get; set; }

        [Display(Name = "Estado", Description = "Estado del Servicio")]
        [Required]
        public int IdEstado { get; set; }


        public int? IdSucursal { get; set; }

        public int IdPersona { get; set; }

        public string Telefono { get; set; }

        public string NombreEstado { get; set; }

        public string NombreRol { get; set; }
    }
}

