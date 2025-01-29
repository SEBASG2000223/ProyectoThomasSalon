using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.ObtenerPoId;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Sucursales.ObtenerPorId;

namespace ThomasSalon.LN.Sucursales.ObtenerPorId
{
    public class ObtenerPorIdSucursalesLN : IObtenerPorIdSucursalesLN
    {
        IObtenerSucursalesPorIdAD _obtenerPorIdAD;

        public ObtenerPorIdSucursalesLN()
        {
            _obtenerPorIdAD = new ObtenerPorIdSucursalesAD();
        }

        public SucursalesDto Obtener(int IdSucursal)
        {
            SucursalesTabla laSucursalEnDb = _obtenerPorIdAD.Obtener(IdSucursal);
            SucursalesDto laSucursalAMostrar = ConvertirASucursalAMostrar(laSucursalEnDb);
            return laSucursalAMostrar;
        }
        private SucursalesDto ConvertirASucursalAMostrar(SucursalesTabla laSucursalEnDb)
        {
            return new SucursalesDto
            {
                IdSucursal = laSucursalEnDb.IdSucursal,
                Nombre = laSucursalEnDb.Nombre,
                LinkDireccion = laSucursalEnDb.LinkDireccion,
                LinkImagen = laSucursalEnDb.LinkImagen,
                Telefono = laSucursalEnDb.Telefono,
                IdEstado = laSucursalEnDb.IdEstado
                
            };
        }
    }
}
