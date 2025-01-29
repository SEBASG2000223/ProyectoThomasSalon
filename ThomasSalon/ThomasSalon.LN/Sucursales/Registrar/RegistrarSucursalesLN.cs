using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.Registrar;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Sucursales;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Registrar;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Sucursales.Registrar;
using ThomasSalon.LN.General.Conversiones;
using ThomasSalon.LN.General.Conversiones.Sucursales;

namespace ThomasSalon.LN.Sucursales.Registrar
{
    public class RegistrarSucursalesLN : IRegistrarSucursalesLN
    {
        IRegistrarSucursalesAD _registrarSucursalesAD;
        IConvertirASucursalesTabla _convertir;

        public RegistrarSucursalesLN()
        {
            _registrarSucursalesAD = new RegistrarSucursalesAD();
        }
        public async Task<int> Registrar(SucursalesDto modelo)
        {
            modelo.IdEstado = 1;
            int cantidadDeDatosGuardados = await _registrarSucursalesAD.Registrar(ConvertirObjetoASucursalesTabla(modelo));
            return cantidadDeDatosGuardados;
        }
        private SucursalesTabla ConvertirObjetoASucursalesTabla(SucursalesDto laSucursal)
        {
            return new SucursalesTabla
            {
                Nombre = laSucursal.Nombre,
                LinkDireccion = laSucursal.LinkDireccion,
                LinkImagen = laSucursal.LinkImagen,
                Telefono = laSucursal.Telefono,
                IdEstado = laSucursal.IdEstado 
            };
        }

    }
}
