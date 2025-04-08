using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("ASISTENCIA_COLABORADORES")]
    public class AsistenciaColaboradorTabla
    {
        [Key]
        public Guid IdAsistencia { get; set; }
        public int IdColaborador { get; set; }
        public int IdTipoJornada { get; set; }
        public int IdSucursal { get; set; }
        public DateTime Fecha { get; set; }

    }
}
