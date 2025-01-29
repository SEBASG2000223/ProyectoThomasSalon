using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.CambiarEstado;

namespace ThomasSalon.AccesoADatos.Proveedores.CambiarEstado
{
    public class CambiarEstadoProveedoresAD : ICambiarEstadoProveedoresAD
    {
        Contexto _elContexto;


        public CambiarEstadoProveedoresAD()
        {
            _elContexto = new Contexto();

        }
        public async Task<int> CambiarEstado(int IdProveedor, int nuevoEstado)
        {
            var proveedor = await _elContexto.ProveedoresTabla
               .FirstOrDefaultAsync(elProveedor => elProveedor.IdProveedor == IdProveedor);

            if (proveedor != null)
            {
                proveedor.IdEstado = nuevoEstado;

                _elContexto.Entry(proveedor).State = EntityState.Modified;
                await _elContexto.SaveChangesAsync();
                return 1;
            }

            return 2;
        }
    }
}
