using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Citas;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Citas.Agendar
{
    public interface IAgendarCitasLN
    {
        Task<int> AgendarCitaPresencial(CitasDto cita, int idSucursal);
        Task<int> AgendarCitaLinea(CitasDto cita, string idUsuario);
        List<string> ObtenerHorariosDisponibles(int idServicio, int idSucursal);
    }
}
