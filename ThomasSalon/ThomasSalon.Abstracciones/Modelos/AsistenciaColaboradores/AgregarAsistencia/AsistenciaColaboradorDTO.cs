using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.AsistenciaColaboradores.AgregarAsistencia
{
    public class AsistenciaColaboradorDTO
    {
        [Required]
        public int IdColaborador { get; set; }
        [Required]
        public int IdTipoJornada { get; set; }
        [Required]
        public int IdSucursal { get; set; }
 

        public DateTime? Fecha { get; set; }



    }
}
