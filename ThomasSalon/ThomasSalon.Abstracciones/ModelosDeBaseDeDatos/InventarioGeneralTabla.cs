using System;
using System.ComponentModel.DataAnnotations;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    public class InventarioGeneralTabla
    {
        [Key]
        public Guid IdInventarioGeneral { get; set; }
        public int IdProducto { get; set; }
        public int CantidadTotal { get; set; }
    }
}
