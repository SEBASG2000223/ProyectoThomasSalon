using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Servicios.CambiarEstado
{
    public interface ICambiarEstadoServiciosAD
    {
        Task<int> CambiarEstado(int IdServicio, int nuevoEstado);
    }
}
