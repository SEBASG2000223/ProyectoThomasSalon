using System;
using System.ComponentModel.DataAnnotations;

namespace ThomasSalon.Abstracciones.Modelos.InventarioGeneral
{
    public class InventarioGeneralDto
    {

        [Display(Name = "Id Inventario", Description = "Id Inventario")]
        [Required]
        public Guid IdInventarioGeneral { get; set; }

        [Display(Name = "Producto", Description = "Producto")]
        [Required]
        public int IdProducto { get; set; }

        [Display(Name = "Cantidad Total", Description = "Cantidad Total del Producto")]
        [Required]
        public int CantidadTotal { get; set; }
    }
}
