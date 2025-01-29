using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.CambiarEstado
{
    public interface ICambiarEstadoProveedoresLN
    {
        Task<int> CambiarEstado(int IdProveedor, int nuevoEstado);
    }
}
