using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("TIPOS_ENTREGA")]
    public class TipoDeEntregaTabla
    {
        [Key]
        public Guid IdTipoEntrega { get; set; }
        public string Nombre { get; set; }

    }
}
