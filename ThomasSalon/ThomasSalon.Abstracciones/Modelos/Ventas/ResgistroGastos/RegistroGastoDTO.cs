using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Ventas.ResgistroGastos
{
    public class RegistroGastoDTO
    {
        public int? IdColaborador { get; set; }
        [Required]

        public int IdSucursal { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal Monto { get; set; }
    }
}
