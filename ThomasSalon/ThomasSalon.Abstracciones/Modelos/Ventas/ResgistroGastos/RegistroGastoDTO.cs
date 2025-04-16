using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Ventas.ResgistroGastos
{
    public class RegistroGastoDTO
    {
        public int IdColaborador { get; set; }
        public int IdSucursal { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
}
