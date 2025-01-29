using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.CambiarEstado
{
    public interface ICambiarEstadoSucursalesLN
    {
        Task<int> CambiarEstado(int IdSucursal, int nuevoEstado);

    }
}
