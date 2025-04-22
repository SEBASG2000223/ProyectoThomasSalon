using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Gastos.ResumenGasto
{
    public class GastoResumenDTO
    {
        public DateTime Fecha { get; set; }
        [Required]
        [Display(Name = "Nombre", Description = "Nombre")]
        public string NombreColaborador { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal Monto { get; set; }
    }

}
