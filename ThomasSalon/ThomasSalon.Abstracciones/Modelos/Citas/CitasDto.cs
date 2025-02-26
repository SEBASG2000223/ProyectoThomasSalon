using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Citas
{
    public class CitasDto
    {
        [Required(ErrorMessage = "La propiedad IdCita es requerida")]
        [Display(Name = "Identificador", Description = "Id Cita")]

        public Guid IdCita { get; set; }

        [Required(ErrorMessage = "La propiedad IdServicio es requerida")]
        [Display(Name = "Id Servicio", Description = "Id Servicio")]
        public int IdServicio { get; set; }

        [Required(ErrorMessage = "La propiedad IdSucursal es requerida")]
        [Display(Name = "Id Sucursal", Description = "Id Sucursal")]
        public int IdSucursal { get; set; }

        [Required(ErrorMessage = "La propiedad IdUsuario es requerida")]
        [Display(Name = "Id Usuario", Description = "Id Usuario")]
        public string IdUsuario { get; set; }

        [Required(ErrorMessage = "La propiedad IdEstadoCita es requerida")]
        [Display(Name = "Estado cita", Description = "Id EstadoCita")]
        public Guid IdEstadoCita { get; set; }

        [Required(ErrorMessage = "La propiedad FechaHora es requerida")]
        [Display(Name = "Fecha", Description = "Fecha de la cita")]
        public DateTime FechaHora { get; set; }

        [Display(Name = "Comentario", Description = "Comentario")]
        public string Comentario { get; set; }

        [Display(Name = "Usuario", Description = "Nombre Usuario")]
        public string nombreUsuario { get; set; }

        [Display(Name = "Servicio", Description = "Nombre Servicio")]
        public string nombreServicio { get; set; }


    }
}
