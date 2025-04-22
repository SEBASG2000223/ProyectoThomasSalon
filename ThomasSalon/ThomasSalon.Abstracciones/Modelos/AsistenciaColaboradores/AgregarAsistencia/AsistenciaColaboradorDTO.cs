using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.AsistenciaColaboradores.AgregarAsistencia
{
    public class AsistenciaColaboradorDTO
    {
        [Required]
        [Display(Name = "Colaborador", Description = "Colaborador")]
        public int IdColaborador { get; set; }
        [Required]
        [Display(Name = "Tipo Jornada", Description = "Tipo Jornada")]
        public int IdTipoJornada { get; set; }
        [Required]
        [Display(Name = "Sucursal", Description = "Sucursal")]
        public int IdSucursal { get; set; }
 

        public DateTime? Fecha { get; set; }



    }
}
