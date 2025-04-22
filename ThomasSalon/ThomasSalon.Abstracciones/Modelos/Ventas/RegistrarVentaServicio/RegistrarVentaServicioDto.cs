using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaServicio
{
    public class RegistrarVentaServicioDTO
    {
        [Required]
        public int IdColaborador { get; set; }
        [Required]
        [Display(Name = "Metodo de Pago", Description = "Metodo de Pago")]
        public Guid IdMetodoPago { get; set; }
        [Required]
        public int IdPersona { get; set; }
        [Required]
        public int IdSucursal { get; set; }
        [Required]
        public List<ServicioVentaDTO> Servicios { get; set; }
        [Required(ErrorMessage = "La propiedad Identificacion es requerida")]
        [Display(Name = "Identificación", Description = "Identificación")]
        [MaxLength(9)]
        [MinLength(9)]
        public string Cedula { get; set; }
        [Required]
        [Display(Name = "Nombre", Description = "Nombre")]
        public string NombrePersona { get; set; }
    }

    public class ServicioVentaDTO
    {
        [Required]
        public int IdServicio { get; set; }
        [Required]
        public decimal Precio { get; set; }
    }

}
