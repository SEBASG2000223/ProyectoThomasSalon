using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("PROVINCIAS")]
    public class ProvinciasTabla
    {
        [Key]
        public Guid IdProvincia { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioEntrega { get; set; }




    }
}
