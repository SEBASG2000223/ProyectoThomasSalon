using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Pagos
{
    public class PagosDto
    {
        [Display(Name = "Identificador", Description = "Id Pago")]
        public int IdPago { get; set; }
        [Display(Name = "Colaborador", Description = "Id Colaborador")]
        public int IdColaborador { get; set; }
        [Display(Name = "Fecha inicio", Description = "Fecha inicio")]
        public DateTime FechaInicioSemana { get; set; }
        [Display(Name = "Fecha fin", Description = "Fecha fin")]
        public DateTime FechaFinSemana { get; set; }
        [Display(Name = "Fecha pago", Description = "Fecha pago")]
        public DateTime FechaPago { get; set; }
        
        [Display(Name = "Dias completos", Description = "Dias completos")]
        public int DiasCompletos { get; set; }
        [Display(Name = "Dias medio tiempos", Description = "Dias medio tiempos")]
        public int DiasMedioTiempos { get; set; }
        [Display(Name = "Total de comisiones", Description = "Total de comisiones")]
        public decimal TotalComision { get; set; }
        [Display(Name = "Total de deducciones", Description = "Total de deducciones")]
        public decimal TotalDeducciones { get; set; }
        [Display(Name = "Total de gastos", Description = "Total de gastos")]
        public decimal TotalGastos { get; set; }
        [Display(Name = "Total del pago", Description = "Total del pago")]
        public decimal TotalPago { get; set; }
    }
}
