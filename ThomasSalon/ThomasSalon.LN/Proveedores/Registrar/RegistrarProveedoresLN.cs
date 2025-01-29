using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.Registrar;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Proveedores;
using ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.Registrar;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Proveedores.Registrar;
using ThomasSalon.LN.General.Conversiones;
using ThomasSalon.LN.General.Conversiones.Proveedores;

namespace ThomasSalon.LN.Proveedores.Registrar
{
    public class RegistrarProveedoresLN : IRegistrarProveedoresLN
    {
        IRegistrarProveedoresAD _registrarProveedoresAD;
        IConvertirAProveedoresTabla _convertir;

        public RegistrarProveedoresLN()
        {
            _registrarProveedoresAD = new RegistrarProveedoresAD();
        }
        public async Task<int> Registrar(ProveedoresDto modelo)
        {
            modelo.IdEstado = 1;
            int cantidadDeDatosGuardados = await _registrarProveedoresAD.Registrar(ConvertirObjetoAProveedoresTabla(modelo));
            return cantidadDeDatosGuardados;
        }
        private ProveedoresTabla ConvertirObjetoAProveedoresTabla(ProveedoresDto elProveedor)
        {
            return new ProveedoresTabla
            {
                Nombre = elProveedor.Nombre,
                Descripcion = elProveedor.Descripcion,
                Telefono = elProveedor.Telefono,
                Direccion = elProveedor.Direccion,
                IdEstado = elProveedor.IdEstado
            };
        }
    }
}