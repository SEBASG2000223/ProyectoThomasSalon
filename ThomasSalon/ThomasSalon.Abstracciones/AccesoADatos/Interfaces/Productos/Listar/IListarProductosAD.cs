using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.Abstracciones.Modelos.Sucursales;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.Listar
{
    public interface IListarProductosAD
    {
        List<ProductosDto> Listar();
        Dictionary<int, string> ObtenerProveedoresPorProducto();
    }
}
