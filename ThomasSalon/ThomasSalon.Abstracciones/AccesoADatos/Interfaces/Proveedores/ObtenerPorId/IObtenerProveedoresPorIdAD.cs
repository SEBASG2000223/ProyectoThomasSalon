using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.ObtenerPorId
{
    public interface IObtenerProveedoresPorIdAD
    {
        ProveedoresTabla Obtener(int IdProveedor);
    }
}
