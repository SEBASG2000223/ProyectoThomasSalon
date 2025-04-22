using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.AsistenciaColaboradores
{
    public class AsistenciaDTO
    {
        public DateTime Fecha { get; set; }
        [Required]
        [Display(Name = "Nombre", Description = "Nombre")]
        public string NombreColaborador { get; set; }
        [Required]
        [Display(Name = "Sucursal", Description = "Sucursal")]
        public string TipoJornada { get; set; }
    }
}
