using System;
using System.ComponentModel.DataAnnotations;

namespace ThomasSalon.Abstracciones.Modelos.InventarioGeneral
{
    public class InventarioGeneralDto
    {

        [Display(Name = "Id Inventario", Description = "Id Inventario")]
        [Required]
        public Guid IdInventarioGeneral { get; set; }

        [Display(Name = "Identificador", Description = "Id del producto")]
        [Required]
        public int IdProducto { get; set; }

        [Display(Name = "Cantidad Total", Description = "Cantidad Total del Producto")]
        [Required]
        public int CantidadTotal { get; set; }

        [Display(Name = "Nombre del producto", Description = "Nombre del producto")]
        public string NombreProducto { get; set; }

        [Display(Name = "Proveedor", Description = "Nombre del proveedor")]
        public string NombreProveedor { get; set; }
    }
}
