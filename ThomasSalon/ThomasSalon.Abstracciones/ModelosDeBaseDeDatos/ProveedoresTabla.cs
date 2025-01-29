using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    public class ProveedoresTabla
    {
        [Key]
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int IdEstado { get; set; }
    }
}
