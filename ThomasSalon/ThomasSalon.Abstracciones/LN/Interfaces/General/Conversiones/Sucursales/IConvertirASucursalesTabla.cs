using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Sucursales
{
    public interface IConvertirASucursalesTabla
    {
        SucursalesTabla ConvertirObjetoASucursalesTabla(SucursalesDto laSucursal);

    }
}
