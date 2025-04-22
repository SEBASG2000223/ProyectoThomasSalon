using System.ComponentModel.DataAnnotations;

namespace ThomasSalon.Abstracciones.Modelos.Proveedores
{
    public class ProveedoresDto
    {
        [Display(Name = "Id Proveedor", Description = "Id Proveedor")]
        public int IdProveedor { get; set; }

        [Display(Name = "Nombre", Description = "Nombre")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Descripción", Description = "Descripción")]
        [StringLength(250, ErrorMessage = "La descripción no debe exceder los 250 caracteres.")]
        [Required]
        public string Descripcion { get; set; }

        [Display(Name = "Teléfono", Description = "Teléfono")]
        [Phone(ErrorMessage = "Ingrese un número de teléfono válido.")]
        [StringLength(20, ErrorMessage = "El teléfono no debe exceder los 20 caracteres.")]
        [Required]
        public string Telefono { get; set; }

        [Display(Name = "Dirección", Description = "Dirección")]
        [StringLength(200, ErrorMessage = "La dirección no debe exceder los 200 caracteres.")]
        [Required]
        public string Direccion { get; set; }

        [Display(Name = "Estado", Description = "Estado")]
        [Required]
        public int IdEstado { get; set; }
        [Display(Name = "Estado", Description = "Estado")]
        public string NombreEstado { get; set; }
    }
}
