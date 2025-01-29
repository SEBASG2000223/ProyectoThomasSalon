using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.ObtenerPorId;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Productos.ObtenerPorId
{
    public class ObtenerPorIdProductosAD : IObtenerProductosPorIdAD
    {
        Contexto _elContexto;

        public ObtenerPorIdProductosAD()
        {
            _elContexto = new Contexto();
        }
        public ProductosTabla Obtener(int IdProducto)
        {
            ProductosTabla elProductoEnBD = _elContexto.ProductosTabla.Where(elProducto => elProducto.IdProducto == IdProducto).FirstOrDefault();
            return elProductoEnBD;
        }
    }
}