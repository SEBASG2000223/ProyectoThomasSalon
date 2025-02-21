using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;

namespace ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal.Editar
{
    public interface IEditarInventarioSucursalLN
    {
        Task<int> Editar(InventarioSucursalDto elInventarioSucursalEnVista);
    }
}
