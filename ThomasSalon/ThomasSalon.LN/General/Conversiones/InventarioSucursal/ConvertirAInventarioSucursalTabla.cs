using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.InventarioSucursal;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.LN.General.Conversiones.InventarioSucursal
{
    public class ConvertirAInventarioSucursalTabla : IConvertirAInventarioSucursalTabla
    {
        public InventarioSucursalTabla ConvertirObjetoAInventarioSucursalTabla(InventarioSucursalDto elInventario)
        {
            return new InventarioSucursalTabla
            {
                IdProducto = elInventario.IdProducto,
                IdSucursal = elInventario.IdSucursal,
                Cantidad = elInventario.Cantidad
            };
        }
    }
}
