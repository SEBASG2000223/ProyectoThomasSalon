using System;
using System.Linq;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioSucursal.ObtenerPorId;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.InventarioSucursal.ObtenerPorId
{
    public class ObtenerInventarioSucursalPorIdAD : IObtenerInventarioSucursalPorIdAD
    {
        Contexto _elContexto;

        public ObtenerInventarioSucursalPorIdAD()
        {
            _elContexto = new Contexto();
        }
        public InventarioSucursalTabla Obtener(int idProducto, int idSucursal)
        {
            return _elContexto.InventarioSucursalTabla
                .Where(inventario => inventario.IdProducto == idProducto && inventario.IdSucursal == idSucursal)
                .FirstOrDefault();
        }

    }
}
