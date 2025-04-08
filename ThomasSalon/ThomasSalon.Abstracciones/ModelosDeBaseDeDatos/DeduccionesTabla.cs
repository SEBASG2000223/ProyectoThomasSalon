using System;
using System.ComponentModel.DataAnnotations;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    public class DeduccionesTabla
    {
        [Key]
        public Guid IdDeduccion { get; set; }
        public int IdColaborador { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoSemanal { get; set; }
        public decimal TotalSaldo { get; set; }
    }
}
