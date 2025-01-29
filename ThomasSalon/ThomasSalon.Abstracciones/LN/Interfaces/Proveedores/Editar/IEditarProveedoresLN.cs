using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.Modelos.Sucursales;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.Editar
{
    public interface IEditarProveedoresLN
    {
        Task<int> Editar(ProveedoresDto elProveedorEnVista);
    }
}
