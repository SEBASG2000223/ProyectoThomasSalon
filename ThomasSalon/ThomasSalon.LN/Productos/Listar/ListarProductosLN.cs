using System.Collections.Generic;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Listar;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.AccesoADatos.Productos.Listar;

namespace ThomasSalon.LN.Productos.Listar
{
    public class ListarProductosLN : IListarProductosLN
    {
        IListarProductosAD _listarProductosAD;

        public ListarProductosLN()
        {
            _listarProductosAD = new ListarProductosAD();
        }
        public List<ProductosDto> Listar()
        {
            List<ProductosDto> laListaDeProductos = _listarProductosAD.Listar();
            return laListaDeProductos;
        }
        public Dictionary<int, string> ObtenerProveedoresPorProducto()
        {
            Dictionary<int, string> DiccionarioProveedores = _listarProductosAD.ObtenerProveedoresPorProducto();
            return DiccionarioProveedores;

        }
        public List<ProductosDto> ProductosActivos()
        {
            List<ProductosDto> laListaDeProductos = _listarProductosAD.ProductosActivos();
            return laListaDeProductos;
        }
    }
}