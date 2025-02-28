using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("ESTADO_CITA")]
    public class EstadoCitaTabla
    {
        [Key]
        public Guid IdEstadoCita {  get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }
}
