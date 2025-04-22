using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Servicios
{
    public class ServiciosDto
    {
        [Display(Name = "Id Servicio", Description = "Id Servicio")]
        public int IdServicio { get; set; }

        [Display(Name = "Nombre", Description = "Nombre del Servicio")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Descripción", Description = "Descripción del Servicio")]
        [StringLength(200, ErrorMessage = "La Descripcion no debe exceder los 200 caracteres.")]
        [Required]
        public string Descripcion { get; set; }

        [Display(Name = "Precio", Description = "Precio del Servicio")]
        [Required]
        public decimal Precio { get; set; }

        [Display(Name = "Duración", Description = "Duración del Servicio")]
        [Required]
        public TimeSpan Duracion { get; set; }

        [Display(Name = "Estado", Description = "Estado del Servicio")]
        [Required]
        public int IdEstado { get; set; }

        [Display(Name = "Tipo de servicio", Description = "Tipo del Servicio")]
        [Required]
        public int IdTipoServicios { get; set; }

        [Display(Name = "Imagen de referencia", Description = "Link de la imagen")]
        [Url(ErrorMessage = "Debe ingresar una URL válida.")]
        [Required]
        public string LinkImagen { get; set; }
        [Display(Name = "Estado", Description = "Estado")]
        public string NombreEstado { get; set; }
    }
}
