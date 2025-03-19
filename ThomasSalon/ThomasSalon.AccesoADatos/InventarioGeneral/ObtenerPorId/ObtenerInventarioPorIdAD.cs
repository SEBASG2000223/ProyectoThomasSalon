using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioGeneral.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.InventarioGeneral;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;

namespace ThomasSalon.AccesoADatos.InventarioGeneral.ObtenerPorId
{
    public class ObtenerInventarioPorIdAD : IObtenerInventarioPorIdAD
    {
        Contexto _elContexto;

        public ObtenerInventarioPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public List<InventarioGeneralDto> DetallesInventario(Guid IdInventarioGeneral)
        {
            List<InventarioGeneralDto> laListaInventario = (from Inventario in _elContexto.InventarioGeneralTabla
                                                            join elProducto in _elContexto.ProductosTabla
                                                            on Inventario.IdProducto equals elProducto.IdProducto
                                                            join elProveedor in _elContexto.ProveedoresTabla
                                                            on elProducto.IdProveedor equals elProveedor.IdProveedor
                                                            join elEstado in _elContexto.EstadoDisponibilidadTabla
                                                            on elProducto.IdEstado equals elEstado.IdEstado
                                                            where Inventario.IdInventarioGeneral == IdInventarioGeneral
                                                            select new InventarioGeneralDto
                                                            {
                                                                IdInventarioGeneral = Inventario.IdInventarioGeneral,
                                                                IdProducto = Inventario.IdProducto,
                                                                NombreProducto = elProducto.Nombre,
                                                                Precio = elProducto.Precio,
                                                                NombreProveedor = elProveedor.Nombre,
                                                                IdEstado = Inventario.IdEstado,
                                                                Descripcion = elProducto.Descripcion,
                                                                UnidadMedida = elProducto.UnidadMedida,


                                                            }).ToList();
            return laListaInventario;
        }
    }
}
