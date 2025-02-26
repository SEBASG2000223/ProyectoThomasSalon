using System;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;

namespace ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal
{
    public interface IObtenerInventarioSucursalPorIdLN
    {
        InventarioSucursalDto Obtener(int idProducto, int idSucursal);
    }
}
