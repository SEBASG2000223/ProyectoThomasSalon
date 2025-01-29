using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Productos
{
    public class ProductosDto
    {
        [Display(Name = "Id Producto", Description = "Id Producto")]
        public int IdProducto { get; set; }

        [Display(Name = "Nombre", Description = "Nombre")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Descripción", Description = "Descripción")]
        [Required]
        public string Descripcion { get; set; }

        [Display(Name = "Precio", Description = "Precio")]
        [Required]
        public decimal Precio { get; set; }

        [Display(Name = "Id Proveedor", Description = "Id Proveedor")]
        [Required]
        public int IdProveedor { get; set; }

        [Display(Name = "Unidad de Medida", Description = "Unidad de Medida")]
        [Required]
        public int UnidadMedida { get; set; }

        [Display(Name = "Estado", Description = "Estado")]
        [Required]
        public int IdEstado { get; set; }

        public string NombreProveedor { get; set; }

        public string NombreEstado { get; set; }
    }
}
