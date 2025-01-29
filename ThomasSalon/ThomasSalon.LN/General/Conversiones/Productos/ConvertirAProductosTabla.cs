using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Productos;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.LN.General.Conversiones.Productos
{
    internal class ConvertirAProductosTabla : IConvertirAProductosTabla
    {
        public ProductosTabla ConvertirObjetoAProductosTabla(ProductosDto elProducto)
        {
            return new ProductosTabla
            {
                IdProducto = elProducto.IdProducto,
                Nombre = elProducto.Nombre,
                Descripcion = elProducto.Descripcion,
                Precio = elProducto.Precio,
                IdProveedor = elProducto.IdProveedor,
                UnidadMedida = elProducto.UnidadMedida,
                IdEstado = elProducto.IdEstado
            };
        }
    }
}