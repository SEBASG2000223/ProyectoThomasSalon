using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.Modelos.Sucursales;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.Listar
{
    public interface IListarProveedoresAD
    {
        List<ProveedoresDto> Listar();
        //List<ProveedoresDto> ObtenerProveedores();
    }
}
