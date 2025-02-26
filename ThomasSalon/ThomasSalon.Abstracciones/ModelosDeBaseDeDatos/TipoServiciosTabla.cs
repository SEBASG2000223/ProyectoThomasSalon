using System.ComponentModel.DataAnnotations;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    public class TipoServiciosTabla
    {

        [Key]
        public int IdTipoServicios { get; set; }

        public string Nombre { get; set; }
    }
}
