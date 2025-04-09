using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    public class PagosTabla
    {
        [Key]
        public int IdPago { get; set; }
        public int IdColaborador { get; set; }
        public DateTime FechaInicioSemana { get; set; }
        public DateTime FechaFinSemana { get; set; }
        public int DiasCompletos { get; set; }
        public int DiasMedioTiempos { get; set; }
        public decimal TotalComision { get; set; }
        public decimal TotalDeducciones { get; set; }
        public decimal TotalGastos { get; set; }
        public decimal TotalPago { get; set; }
    }
}
