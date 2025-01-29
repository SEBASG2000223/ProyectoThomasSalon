using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.ObtenerPoId;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.ObtenerPorId;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Sucursales.ObtenerPorId
{
    public class ObtenerPorIdSucursalesAD : IObtenerSucursalesPorIdAD
    {
        Contexto _elContexto;

        public ObtenerPorIdSucursalesAD()
        {
            _elContexto = new Contexto();
        }
        public SucursalesTabla Obtener(int IdSucursal)
        {
            SucursalesTabla laSucursalEnBD = _elContexto.SucursalesTabla.Where(laSucursal => laSucursal.IdSucursal == IdSucursal).FirstOrDefault();
            return laSucursalEnBD;
        }
    }
}
