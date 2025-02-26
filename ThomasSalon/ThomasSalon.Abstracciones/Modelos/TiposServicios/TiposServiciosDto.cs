using System.ComponentModel.DataAnnotations;

namespace ThomasSalon.Abstracciones.Modelos.TiposServicios
{
    public class TiposServiciosDto
    {

        [Display(Name = "Id Tipo Servicio", Description = "Id Tipo Servicio")]
        public int IdTipoServicios {  get; set; }

        [Display(Name = "Categoria de servicio", Description = "Categoria de Servicio")]
        public string Nombre { get; set; }
    }
}
