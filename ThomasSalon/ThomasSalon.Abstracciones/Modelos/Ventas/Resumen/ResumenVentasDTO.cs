using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Ventas.Resumen
{
    public class ResumenVentasDTO
    {
        [Required]
        public Guid IdVenta { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]

        public decimal MontoTotal { get; set; }
        [Required]
        public string NombreCliente { get; set; }
        [Required]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener exactamente 8 dígitos.")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "La propiedad Identificacion es requerida")]
        [MaxLength(9)]
        [MinLength(9)]
        public string Identificacion { get; set; }
        [Required]
        [Display(Name = "Nombre colaborador", Description = "Nombre colaborador")]
        public string NombreColaborador { get; set; }
        [Required]
        [Display(Name = "Metodo de Pago", Description = "Metodo de Pago")]
        public string MetodoPago { get; set; }
        [Required]
        [Display(Name = "Sucursal", Description = "Sucursal")]
        public string NombreSucursal { get; set; }
        [Required]
        [Display(Name = "Total Dia", Description = "Total Dia")]
        public decimal MontoTotalDia { get; set; }
        [Required]
        [Display(Name = "Total Transferencias", Description = "Total Transferencias")]
        public decimal MontoTotalTransferencias { get; set; }
        [Required]
        [Display(Name = "Total Sinpe", Description = "Total Sinpe")]
        public decimal MontoTotalSinpe { get; set; }
        [Required]
        [Display(Name = "Total Tarjeta", Description = "Total Tarjeta")]
        public decimal MontoTotalTarjeta { get; set; }
        [Required]
        [Display(Name = "Total Efectivo", Description = "Total Efectivo")]
        public decimal MontoTotalEfectivo { get; set; }
        [Required]
        [Display(Name = "Total Gastos", Description = "Total Gastos")]
        public decimal MontoTotalGastos { get; set; }
    }
}
