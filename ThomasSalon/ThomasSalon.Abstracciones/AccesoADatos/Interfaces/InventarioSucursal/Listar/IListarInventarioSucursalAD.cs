using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;

namespace ThomasSalon.Abstracciones.AccesoADatos.InventarioSucursal
{
    public interface IListarInventarioSucursalAD
    {
        List<InventarioSucursalDto> Listar();
    }
}
