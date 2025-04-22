using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Deducciones;
using ThomasSalon.Abstracciones.Modelos.Personas;

namespace ThomasSalon.Abstracciones.Modelos.Colaboradores
{
    public class ColaboradoresDto
    {
        [Display(Name = "Colaborador", Description = "Id Colaborador")]
        [Required(ErrorMessage = "La propiedad colaborador es requerida.")]
        public int? IdColaborador { get; set; }

        [Required(ErrorMessage = "El salario por día es requerido.")]
        [Display(Name = "Salario", Description = "Salario")]
        public decimal SalarioDia { get; set; }

        [Required(ErrorMessage = "El estado es requerido.")]
    

        public int IdEstado { get; set; }

        [Required(ErrorMessage = "La persona es requerida.")]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El teléfono es requerido.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El número de teléfono debe tener exactamente 8 dígitos.")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "La dirección es requerida.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La edad es requerida.")]
        [Range(15, int.MaxValue, ErrorMessage = "La edad debe ser mayor a 15.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El nombre del estado es requerido.")]
        [Display(Name = "Estado", Description = "Estado")]
        public string NombreEstado { get; set; }

        [Required(ErrorMessage = "El género es requerido.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "La propiedad Identificacion es requerida")]
        [MaxLength(9)]
        [MinLength(9)]
        public string Identificacion { get; set; }

        public DateTime? FechaUltimoPago { get; set; }

        public PersonasDto Persona { get; set; }

        public bool TieneUsuario { get; set; }
    }
}