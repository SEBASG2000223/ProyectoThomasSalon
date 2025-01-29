using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.CambiarEstado;

namespace ThomasSalon.AccesoADatos.Sucursales.CambiarEstado
{
    public class CambiarEstadoSucursalesAD : ICambiarEstadoSucursalesAD
    {
        Contexto _elContexto;
      

        public CambiarEstadoSucursalesAD()
        {
            _elContexto = new Contexto();
         
        }
        public async Task<int> CambiarEstado(int IdSucursal, int nuevoEstado)
        {
            var sucursal = await _elContexto.SucursalesTabla
               .FirstOrDefaultAsync(laSucursal => laSucursal.IdSucursal == IdSucursal);

            if (sucursal != null)
            {
                sucursal.IdEstado = nuevoEstado;
               
                _elContexto.Entry(sucursal).State = EntityState.Modified;
                await _elContexto.SaveChangesAsync();
                return 1;
            }

            return 2;
        }
    }
}
