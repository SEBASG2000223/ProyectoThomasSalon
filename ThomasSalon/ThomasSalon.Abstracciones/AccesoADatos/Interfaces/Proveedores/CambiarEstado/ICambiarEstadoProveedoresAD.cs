using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.CambiarEstado
{
    public interface ICambiarEstadoProveedoresAD
    {
        Task<int> CambiarEstado(int IdProveedor, int nuevoEstado);
    }
}
