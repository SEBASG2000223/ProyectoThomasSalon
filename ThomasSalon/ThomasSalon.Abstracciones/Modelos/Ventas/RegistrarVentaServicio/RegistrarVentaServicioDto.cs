using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaServicio
{
    public class RegistrarVentaServicioDTO
    {
        public int IdColaborador { get; set; }
        public Guid IdMetodoPago { get; set; }
        public int IdPersona { get; set; }
        public int IdSucursal { get; set; }
        public List<ServicioVentaDTO> Servicios { get; set; }  // Lista de servicios
        public string Cedula { get; set; }
        public string NombrePersona { get; set; }
    }

    public class ServicioVentaDTO
    {
        public int IdServicio { get; set; }
        public decimal Precio { get; set; }
    }

}
