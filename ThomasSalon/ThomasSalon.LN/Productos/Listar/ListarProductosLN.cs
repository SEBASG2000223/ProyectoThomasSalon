using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}