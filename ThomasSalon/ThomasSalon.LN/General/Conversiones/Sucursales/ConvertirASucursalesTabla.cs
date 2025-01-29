using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Sucursales;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.LN.General.Conversiones.Sucursales
{
    internal class ConvertirASucursalesTabla : IConvertirASucursalesTabla
    {
        public SucursalesTabla ConvertirObjetoASucursalesTabla(SucursalesDto laSucursal)
        {
            return new SucursalesTabla
            {
                IdSucursal = laSucursal.IdSucursal,
                Nombre = laSucursal.Nombre,
                LinkDireccion = laSucursal.LinkDireccion,
                LinkImagen = laSucursal.LinkImagen,
                Telefono = laSucursal.Telefono,
                IdEstado = laSucursal.IdEstado,
              
     
            };
        }
    }
}
