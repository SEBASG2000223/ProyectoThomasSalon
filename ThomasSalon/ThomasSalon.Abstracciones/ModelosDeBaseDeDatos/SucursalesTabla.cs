using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("SUCURSALES")]
    public class SucursalesTabla
    {
        [Key]
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
        public string LinkDireccion { get; set; }
        public string LinkImagen { get; set; }
        public string Telefono { get; set; }
        public int IdEstado { get; set; }
    }
}
