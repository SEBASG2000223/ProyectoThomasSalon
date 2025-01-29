using System;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Proveedores.ObtenerPorId;

namespace ThomasSalon.LN.Proveedores.ObtenerPorId
{
    public class ObtenerProveedoresPorIdLN : IObtenerProveedoresPorIdLN
    {
        IObtenerProveedoresPorIdAD _obtenerPorIdAD;

        public ObtenerProveedoresPorIdLN()
        {
            _obtenerPorIdAD = new ObtenerPorIdProveedoresAD();
        }

        public ProveedoresDto Obtener(int IdProveedor)
        {
            ProveedoresTabla elProveedorEnDb = _obtenerPorIdAD.Obtener(IdProveedor);
            ProveedoresDto elProveedorAMostrar = ConvertirAProveedorAMostrar(elProveedorEnDb);
            return elProveedorAMostrar;
        }

        private ProveedoresDto ConvertirAProveedorAMostrar(ProveedoresTabla elProveedorEnDb)
        {
            return new ProveedoresDto
            {
                IdProveedor = elProveedorEnDb.IdProveedor,
                Nombre = elProveedorEnDb.Nombre,
                Descripcion = elProveedorEnDb.Descripcion,
                Telefono = elProveedorEnDb.Telefono,
                Direccion = elProveedorEnDb.Direccion,
                IdEstado = elProveedorEnDb.IdEstado
            };
        }
    }
}