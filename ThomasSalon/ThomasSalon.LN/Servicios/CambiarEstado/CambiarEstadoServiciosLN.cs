using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Servicios.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.CambiarEstado;
using ThomasSalon.AccesoADatos.Servicios.CambiarEstado;

namespace ThomasSalon.LN.Servicios.CambiarEstado
{
    public class CambiarEstadoServiciosLN : ICambiarEstadoServiciosLN
    {
        ICambiarEstadoServiciosAD _cambiarEstado;

        public CambiarEstadoServiciosLN()
        {
            _cambiarEstado = new CambiarEstadoServiciosAD();
        }
        public async Task<int> CambiarEstado(int IdServicio, int nuevoEstado)
        {
            return await _cambiarEstado.CambiarEstado(IdServicio, nuevoEstado);
        }
    }
}