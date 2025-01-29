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
                await _elContexto.SaveChangesAsync();
                return 1;
            }

            return 2;
        }
    }
}
