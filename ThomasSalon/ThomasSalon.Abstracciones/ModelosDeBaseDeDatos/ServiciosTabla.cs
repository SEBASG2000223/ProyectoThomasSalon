using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    public class ServiciosTabla
    {
        [Key]
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public TimeSpan Duracion { get; set; }
        public int IdEstado { get; set; }
        public int IdTipoServicios { get; set; }
        public string LinkImagen { get; set; }
    }
}
