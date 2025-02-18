using System.Collections.Generic;
using System.Linq;
using ThomasSalon.Abstracciones.AccesoADatos.InventarioSucursal;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.Abstracciones.Modelos.Productos;

namespace ThomasSalon.AccesoADatos.InventarioSucursal.Listar
{
    public class ListarInventarioSucursalAD : IListarInventarioSucursalAD

    {
        Contexto _elContexto;

        public ListarInventarioSucursalAD()
        {
            _elContexto = new Contexto();
        }
        public List<InventarioSucursalDto> Listar(int idSucursal)
        {
            List<InventarioSucursalDto> laListaInventario = (from Inventario in _elContexto.InventarioSucursalTabla
                                                             join sucursal in _elContexto.SucursalesTabla
                                                             on Inventario.IdSucursal equals sucursal.IdSucursal
                                                             join elProducto in _elContexto.ProductosTabla
                                                             on Inventario.IdProducto equals elProducto.IdProducto
                                                             join elProveedor in _elContexto.ProveedoresTabla
                                                             on elProducto.IdProveedor equals elProveedor.IdProveedor
                                                             join elEstado in _elContexto.EstadoDisponibilidadTabla
                                                             on elProducto.IdEstado equals elEstado.IdEstado
                                                             where Inventario.IdSucursal == idSucursal
                                                             select new InventarioSucursalDto
                                                             {
                                                                 IdInventarioSucursal = Inventario.IdInventarioSucursal,
                                                                 IdProducto = Inventario.IdProducto,
                                                                 NombreProducto = elProducto.Nombre,
                                                                 Precio = elProducto.Precio,
                                                                 NombreProveedor = elProveedor.Nombre,
                                                                 Cantidad = Inventario.Cantidad,
                                                                 IdEstado = Inventario.IdEstado,
                                                             }).ToList();
            return laListaInventario;
        }




    }
}
