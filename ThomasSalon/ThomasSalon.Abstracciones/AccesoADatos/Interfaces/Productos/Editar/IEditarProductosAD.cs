using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.Editar
{
    public interface IEditarProductosAD
    {
        Task<int> Editar(ProductosTabla elProductoParaEditar);
    }
}
