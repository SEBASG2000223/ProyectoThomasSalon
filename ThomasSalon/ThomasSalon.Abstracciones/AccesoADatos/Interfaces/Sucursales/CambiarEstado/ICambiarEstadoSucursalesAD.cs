using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.CambiarEstado
{
    public interface ICambiarEstadoSucursalesAD
    {
        Task<int> CambiarEstado(int IdSucursal, int nuevoEstado);

    }
}
