using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Servicios.CambiarEstado
{
    public interface ICambiarEstadoServiciosLN
    {
        Task<int> CambiarEstado(int IdServicio, int nuevoEstado);
    }
}
