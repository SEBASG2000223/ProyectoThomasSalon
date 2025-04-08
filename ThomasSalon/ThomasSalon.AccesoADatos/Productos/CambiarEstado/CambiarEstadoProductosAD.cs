using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.CambiarEstado;

namespace ThomasSalon.AccesoADatos.Productos.CambiarEstado
{
    public class CambiarEstadoProductosAD : ICambiarEstadoProductosAD
    {
        Contexto _elContexto;


        public CambiarEstadoProductosAD()
        {
            _elContexto = new Contexto();

        }
        public async Task<int> CambiarEstado(int IdProducto, int nuevoEstado)
        {
            var producto = await _elContexto.ProductosTabla
               .FirstOrDefaultAsync(elProducto => elProducto.IdProducto == IdProducto);

            if (producto != null)
            {
                producto.IdEstado = nuevoEstado;
                _elContexto.Entry(producto).State = EntityState.Modified;

                var inventariosGenerales = await _elContexto.InventarioGeneralTabla
                    .Where(inventarioGeneral => inventarioGeneral.IdProducto == IdProducto)
                    .ToListAsync();

                foreach (var inventarioGeneral in inventariosGenerales)
                {
                    inventarioGeneral.IdEstado = nuevoEstado;
                    _elContexto.Entry(inventarioGeneral).State = EntityState.Modified;
                }

                var inventariosSucursales = await _elContexto.InventarioSucursalTabla
                    .Where(inventarioSucursal => inventarioSucursal.IdProducto == IdProducto)
                    .ToListAsync();

                foreach (var inventarioSucursal in inventariosSucursales)
                {
                    inventarioSucursal.IdEstado = nuevoEstado;
                    _elContexto.Entry(inventarioSucursal).State = EntityState.Modified;
                }


                await _elContexto.SaveChangesAsync();
                return 1; 
            }

            return 2;
        }
    }
}
