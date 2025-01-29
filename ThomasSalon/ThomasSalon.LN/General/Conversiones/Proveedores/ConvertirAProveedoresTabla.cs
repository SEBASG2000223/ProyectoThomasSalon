using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Proveedores;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.LN.General.Conversiones.Proveedores
{
    internal class ConvertirAProveedoresTabla : IConvertirAProveedoresTabla
    {
        public ProveedoresTabla ConvertirObjetoAProveedoresTabla(ProveedoresDto elProveedor)
        {
            return new ProveedoresTabla
            {
                IdProveedor = elProveedor.IdProveedor,
                Nombre = elProveedor.Nombre,
                Descripcion = elProveedor.Descripcion,
                Telefono = elProveedor.Telefono,
                Direccion = elProveedor.Direccion,
                IdEstado = elProveedor.IdEstado
            };
        }
    }
}