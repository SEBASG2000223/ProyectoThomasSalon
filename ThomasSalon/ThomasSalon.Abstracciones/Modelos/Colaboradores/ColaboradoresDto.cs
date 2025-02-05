using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Colaboradores
{
    public class ColaboradoresDto
    {
        [Display(Name = "Id Colaborador", Description = "Id Colaborador")]
        public int IdColaborador { get; set; }

        [Display(Name = "Nombre", Description = "Nombre")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Teléfono", Description = "Teléfono")]
        [Required]
        public string Telefono { get; set; }

        [Display(Name = "Salario por Día", Description = "Salario por Día")]
        [Required]
        public decimal SalarioDia { get; set; }

        [Display(Name = "Estado", Description = "Estado")]
        [Required]
        public int IdEstado { get; set; }

        public string NombreEstado { get; set; }
    }
}