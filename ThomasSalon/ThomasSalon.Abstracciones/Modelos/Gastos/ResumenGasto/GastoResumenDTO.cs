using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Gastos.ResumenGasto
{
    public class GastoResumenDTO
    {
        public DateTime Fecha { get; set; }
        public string NombreColaborador { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }

}
