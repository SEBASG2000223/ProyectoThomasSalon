using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.CambiarEstado;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.CambiarEstado;
using ThomasSalon.AccesoADatos.Sucursales.CambiarEstado;
using ThomasSalon.AccesoADatos.Usuarios.CambiarEstado;

namespace ThomasSalon.LN.Usuarios.CambiarEstado
{
    public class CambiarEstadoUsuariosLN : ICambiarEstadoUsuariosLN
    {
        ICambiarEstadoUsuariosAD _cambiarEstado;

        public CambiarEstadoUsuariosLN()
        {
            _cambiarEstado = new CambiarEstadoUsuariosAD();
        }
        public async Task<int> CambiarEstado(string IdUsuario, int nuevoEstado)
        {
            return await _cambiarEstado.CambiarEstado(IdUsuario, nuevoEstado);
        }
    }
}
