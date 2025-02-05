using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    public class ColaboradoresTabla
    {
        [Key]
        public int IdColaborador { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public decimal SalarioDia { get; set; }

        public int IdEstado { get; set; }
    }
}
