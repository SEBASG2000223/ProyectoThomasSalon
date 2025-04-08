using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.AsistenciaColaboradores
{
    public class AsistenciaDTO
    {
        public DateTime Fecha { get; set; }
        public string NombreColaborador { get; set; }
        public string TipoJornada { get; set; }
    }
}
