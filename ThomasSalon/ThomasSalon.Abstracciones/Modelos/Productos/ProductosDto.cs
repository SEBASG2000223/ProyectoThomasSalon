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
        [StringLength(200, ErrorMessage = "La Descripcion no debe exceder los 200 caracteres.")]
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
        [Range(1, 5000, ErrorMessage = "La unidad de medida debe estar entre 1 y 5000 mililitros.")]
        public int UnidadMedida { get; set; }

        [Display(Name = "Estado", Description = "Estado")]
        [Required]
        public int IdEstado { get; set; }

        [Display(Name = "Imagen de referencia", Description = "Link de la imagen")]
        [Url(ErrorMessage = "Debe ingresar una URL válida.")]
        [Required]
        public string LinkImagen { get; set; }

        public string NombreProveedor { get; set; }
    }
}
