using System;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioSucursal.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.InventarioSucursal.ObtenerPorId;

namespace ThomasSalon.LN.InventarioSucursal.ObtenerPorId
{
    public class ObtenerInventarioSucursalPorIdLN : IObtenerInventarioSucursalPorIdLN
    {
        IObtenerInventarioSucursalPorIdAD _obtenerPorIdAD;

        public ObtenerInventarioSucursalPorIdLN()
        {
            _obtenerPorIdAD = new ObtenerInventarioSucursalPorIdAD();
        }

        public InventarioSucursalDto Obtener(int idProducto)
        {
            InventarioSucursalTabla elInventarioEnDb = _obtenerPorIdAD.Obtener(idProducto);
            InventarioSucursalDto elInventarioAMostrar = ConvertirAProductoAMostrar(elInventarioEnDb);
            return elInventarioAMostrar;
        }

        private InventarioSucursalDto ConvertirAProductoAMostrar(InventarioSucursalTabla elInventarioEnDb)
        {
            return new InventarioSucursalDto
            {
                IdInventarioSucursal = elInventarioEnDb.IdInventarioSucursal,
                IdSucursal = elInventarioEnDb.IdSucursal,
                IdProducto = elInventarioEnDb.IdProducto,
                Cantidad = elInventarioEnDb.Cantidad,
                IdEstado = elInventarioEnDb.IdEstado
          

            };
        }
    }
}
