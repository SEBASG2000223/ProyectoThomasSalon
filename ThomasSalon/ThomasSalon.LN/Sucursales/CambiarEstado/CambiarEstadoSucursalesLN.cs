using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.CambiarEstado;
using ThomasSalon.AccesoADatos.Sucursales.CambiarEstado;
using ThomasSalon.LN.General.Conversiones;

namespace ThomasSalon.LN.Sucursales.CambiarEstado
{
    public class CambiarEstadoSucursalesLN : ICambiarEstadoSucursalesLN
    {
        ICambiarEstadoSucursalesAD _cambiarEstado;

        public CambiarEstadoSucursalesLN()
        {
            _cambiarEstado = new CambiarEstadoSucursalesAD();
        }
        public async Task<int> CambiarEstado(int IdSucursal, int nuevoEstado)
        {
            return await _cambiarEstado.CambiarEstado(IdSucursal, nuevoEstado);

        }
    }
}
