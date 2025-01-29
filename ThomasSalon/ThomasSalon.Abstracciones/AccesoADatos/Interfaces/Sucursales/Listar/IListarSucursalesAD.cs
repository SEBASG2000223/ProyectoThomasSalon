using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Sucursales;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.Listar
{
    public interface IListarSucursalesAD
    {
        List<SucursalesDto> Listar();
    }
}
