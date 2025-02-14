using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;

namespace ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal
{
    public interface IListarInventarioSucursalLN
    {
        List<InventarioSucursalDto> Listar();
    }
}
