using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaProducto
{
    public class RegistrarVentaProductoDTO
    {
        [Required]
        public int IdColaborador { get; set; }
        [Required]
        public Guid IdMetodoPago { get; set; }
        [Required]
        public int IdPersona { get; set; }
        [Required]
        public int IdSucursal { get; set; }
        [Required]
        public List<ProductoVentaDTO> Productos { get; set; }
      
        [Required(ErrorMessage = "La propiedad Identificacion es requerida")]
        [Display(Name = "Identificación", Description = "Identificación")]
        [MaxLength(9)]
        [MinLength(9)]
        public string Cedula { get; set; }
        [Required]
        [Display(Name = "Nombre", Description = "Nombre")]

        public string NombrePersona { get; set; }
    }

    public class ProductoVentaDTO
    {
        [Required]
        [Display(Name = "Id Producto", Description = "Id Producto")]
        public int IdProducto { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        [Display(Name = "Precio Unitario", Description = "Precio Unitario")]
        public decimal PrecioUnitario { get; set; }
    }


}
