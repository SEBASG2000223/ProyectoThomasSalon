using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Sucursales;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar
{
    public interface IListarSucursalesLN
    {
        List<SucursalesDto> Listar();
        List<SucursalesDto> ListarSucursalesActivas();
    }
}
