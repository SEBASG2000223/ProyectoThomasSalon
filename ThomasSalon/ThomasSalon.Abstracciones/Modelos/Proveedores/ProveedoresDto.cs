using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Proveedores
{
    public class ProveedoresDto
    {
        [Display(Name = "Id Proveedor", Description = "Id Proveedor")]
        public int IdProveedor { get; set; }

        [Display(Name = "Nombre", Description = "Nombre")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Descripción", Description = "Descripción")]
        [Required]
        public string Descripcion { get; set; }

        [Display(Name = "Teléfono", Description = "Teléfono")]
        [Required]
        public string Telefono { get; set; }

        [Display(Name = "Dirección", Description = "Dirección")]
        [Required]
        public string Direccion { get; set; }

        [Display(Name = "Estado", Description = "Estado")]
        [Required]
        public int IdEstado { get; set; }

        public string NombreEstado { get; set; }
    }
}
