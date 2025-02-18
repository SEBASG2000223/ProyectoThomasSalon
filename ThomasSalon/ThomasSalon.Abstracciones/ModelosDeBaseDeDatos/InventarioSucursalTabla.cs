using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("INVENTARIO_SUCURSAL")]
    public class InventarioSucursalTabla
    {
        [Key]
        public Guid IdInventarioSucursal { get; set; }
        public int IdSucursal { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int IdEstado { get; set; }
    }
}
