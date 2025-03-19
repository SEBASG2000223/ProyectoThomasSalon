using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.Abstracciones.Modelos.Productos;

namespace ThomasSalon.Abstracciones.AccesoADatos.InventarioSucursal
{
    public interface IListarInventarioSucursalAD
    {
        List<InventarioSucursalDto> Listar(int idSucursal);
        List<InventarioSucursalDto> DetallesInventario(Guid IdInventarioSucursal);
        List<ProductosDto> ListarProductosActivos(int idSucursal);
    }
}
