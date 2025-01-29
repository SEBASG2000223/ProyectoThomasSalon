using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Productos.CambiarEstado
{
    public interface ICambiarEstadoProductosLN
    {
        Task<int> CambiarEstado(int IdProducto, int nuevoEstado);
    }
}
