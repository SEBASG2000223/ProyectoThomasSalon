using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    [Table("CITAS")]
    public class CitasTabla
    {
        [Key]
        public Guid IdCita { get; set; }
        public int IdServicio { get; set; }
        public int IdSucursal { get; set; }
        public int IdPersona { get; set; }
        public int? IdColaborador { get; set; }
        public Guid IdEstadoCita { get; set; }
        public DateTime FechaHora { get; set; }

        public string Comentario { get; set; }
    }
}
