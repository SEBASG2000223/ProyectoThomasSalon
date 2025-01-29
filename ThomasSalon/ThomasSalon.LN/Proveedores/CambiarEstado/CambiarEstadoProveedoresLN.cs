using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.CambiarEstado;
using ThomasSalon.AccesoADatos.Proveedores.CambiarEstado;
using ThomasSalon.LN.General.Conversiones;

namespace ThomasSalon.LN.Proveedores.CambiarEstado
{
    public class CambiarEstadoProveedoresLN : ICambiarEstadoProveedoresLN
    {
        ICambiarEstadoProveedoresAD _cambiarEstado;

        public CambiarEstadoProveedoresLN()
        {
            _cambiarEstado = new CambiarEstadoProveedoresAD();
        }
        public async Task<int> CambiarEstado(int IdProveedor, int nuevoEstado)
        {
            return await _cambiarEstado.CambiarEstado(IdProveedor, nuevoEstado);
        }
    }
}