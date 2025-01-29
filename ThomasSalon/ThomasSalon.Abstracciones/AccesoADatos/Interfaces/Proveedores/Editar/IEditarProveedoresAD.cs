using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.Editar
{
    public interface IEditarProveedoresAD
    {
        Task<int> Editar(ProveedoresTabla elProveedorParaEditar);
    }
}
