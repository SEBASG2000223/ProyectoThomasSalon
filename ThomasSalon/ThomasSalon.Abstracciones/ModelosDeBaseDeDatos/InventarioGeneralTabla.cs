using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("INVENTARIO_GENERAL")]
    public class InventarioGeneralTabla
    {
        [Key]
        public Guid IdInventarioGeneral { get; set; }
        public int IdProducto { get; set; }
        public int CantidadTotal { get; set; }
    }
}
