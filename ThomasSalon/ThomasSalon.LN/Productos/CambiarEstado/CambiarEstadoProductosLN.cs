using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.CambiarEstado;
using ThomasSalon.AccesoADatos.Productos.CambiarEstado;
using ThomasSalon.LN.General.Conversiones;

namespace ThomasSalon.LN.Productos.CambiarEstado
{
    public class CambiarEstadoProductosLN : ICambiarEstadoProductosLN
    {
        ICambiarEstadoProductosAD _cambiarEstado;

        public CambiarEstadoProductosLN()
        {
            _cambiarEstado = new CambiarEstadoProductosAD();
        }
        public async Task<int> CambiarEstado(int IdProducto, int nuevoEstado)
        {
            return await _cambiarEstado.CambiarEstado(IdProducto, nuevoEstado);
        }
    }
}