using System;
using System.ComponentModel.DataAnnotations;
using ThomasSalon.Abstracciones.Modelos.Personas;

namespace ThomasSalon.Abstracciones.Modelos.Deducciones
{
    public class DeduccionesDto
    {
        [Required(ErrorMessage = "La propiedad Id Deduccion es requerida")]
        [Display(Name = "Identificador", Description = "Id Deduccion")]
        public Guid IdDeduccion {  get; set; }
        [Required(ErrorMessage = "La propiedad IdColaborador es requerida")]
        [Display(Name = "Colaborador", Description = "Id Colaborador")]
        public int IdColaborador { get; set; }
        [Required(ErrorMessage = "La propiedad MontoSemanal es requerida")]
        [Display(Name = "Monto semanal", Description = "Monto semanal deduccion")]
        public decimal MontoSemanal { get; set; }
        [Required(ErrorMessage = "La propiedad TotalSaldo es requerida")]
        [Display(Name = "Saldo total", Description = "Saldo total deduccion")]
        public decimal TotalSaldo { get; set; }
        [Required(ErrorMessage = "La propiedad MontoAgregado es requerida")]
        [Display(Name = "Monto", Description = "MontoAgregado deduccion")]
        public decimal MontoAgregado { get; set; }
        [Required(ErrorMessage = "La propiedad Descripcion es requerida")]
        [Display(Name = "Descripcion", Description = "Descripcion deduccion")]
        public string Descripcion { get; set; }
        [Display(Name = "Nombre colaborador", Description = "Nombre colaborador")]
        public string nombreColaborador { get; set; }



    }

    
}
