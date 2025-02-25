using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    public class RolesTabla
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
