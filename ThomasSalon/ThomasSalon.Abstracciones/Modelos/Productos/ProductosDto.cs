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
        [Display(Name = "Identificador", Description = "Id Producto")]
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

        [Display(Name = "Proveedor", Description = "Proveedor")]
        [Required]
        public int IdProveedor { get; set; }

        [Display(Name = "Unidad de Medida", Description = "Unidad de Medida")]
        [Required]
        public int UnidadMedida { get; set; }

        [Display(Name = "Estado", Description = "Estado")]
        [Required]
        public int IdEstado { get; set; }

        [Display(Name = "Link Imagen", Description = "Link Imagen")]
        [Required]
        public string LinkImagen { get; set; }

        public string NombreProveedor { get; set; }

        public string NombreEstado { get; set; }
    }
}
