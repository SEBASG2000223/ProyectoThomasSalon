using System;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Productos.ObtenerPorId;

namespace ThomasSalon.LN.Productos.ObtenerPorId
{
    public class ObtenerProductosPorIdLN : IObtenerProductosPorIdLN
    {
        IObtenerProductosPorIdAD _obtenerPorIdAD;

        public ObtenerProductosPorIdLN()
        {
            _obtenerPorIdAD = new ObtenerPorIdProductosAD();
        }

        public ProductosDto Obtener(int IdProducto)
        {
            ProductosTabla elProductoEnDb = _obtenerPorIdAD.Obtener(IdProducto);
            ProductosDto elProductoAMostrar = ConvertirAProductoAMostrar(elProductoEnDb);
            return elProductoAMostrar;
        }

        private ProductosDto ConvertirAProductoAMostrar(ProductosTabla elProductoEnDb)
        {
            return new ProductosDto
            {
                IdProducto = elProductoEnDb.IdProducto,
                Nombre = elProductoEnDb.Nombre,
                Descripcion = elProductoEnDb.Descripcion,
                Precio = elProductoEnDb.Precio,
                IdProveedor = elProductoEnDb.IdProveedor,
                UnidadMedida = elProductoEnDb.UnidadMedida,
                IdEstado = elProductoEnDb.IdEstado
            };
        }
    }
}