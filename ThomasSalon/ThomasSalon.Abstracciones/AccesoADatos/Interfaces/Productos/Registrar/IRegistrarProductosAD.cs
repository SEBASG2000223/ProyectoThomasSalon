using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.Registrar
{
    public interface IRegistrarProductosAD
    {
        Task<int> Registrar(ProductosTabla elProductoAGuardar);
    }
}
