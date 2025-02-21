using System;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioSucursal.ObtenerPorId
{
    public interface IObtenerInventarioSucursalPorIdAD
    {
        InventarioSucursalTabla Obtener(int idProducto);
    }
}
