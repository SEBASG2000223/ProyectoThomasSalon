using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.InventarioSucursal
{
    public interface IConvertirAInventarioSucursalTabla
    {
        InventarioSucursalTabla ConvertirObjetoAProductosTabla(InventarioSucursalDto elInventario);
    }
}
