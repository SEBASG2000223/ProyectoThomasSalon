using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Sucursales
{
    public class SucursalesDto
    {
        [Display(Name = "Sucursal", Description = "Id Sucursal")]
        [Required]
        public int IdSucursal { get; set; }

        [Display(Name = "Nombre", Description = "Nombre")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Link Dirección", Description = "Link Dirección")]
        [Required]
        public string LinkDireccion { get; set; }

        [Display(Name = "Link Imagen", Description = "Link Imagen")]
        [Required]
        public string LinkImagen { get; set; }

        [Display(Name = "Teléfono", Description = "Teléfono")]
        [Required]
        public string Telefono { get; set; }

        [Display(Name = "Estado", Description = "Estado")]
        [Required]
        public int IdEstado { get; set; }

        public string NombreEstado { get; set; }

    }
}
