using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.CambiarEstado
{
    public interface ICambiarEstadoProductosAD
    {
        Task<int> CambiarEstado(int IdProducto, int nuevoEstado);
    }
}
