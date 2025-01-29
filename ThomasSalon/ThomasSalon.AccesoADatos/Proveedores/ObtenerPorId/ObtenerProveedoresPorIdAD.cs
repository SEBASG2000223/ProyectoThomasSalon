using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.ObtenerPorId;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Proveedores.ObtenerPorId
{
    public class ObtenerPorIdProveedoresAD : IObtenerProveedoresPorIdAD
    {
        Contexto _elContexto;

        public ObtenerPorIdProveedoresAD()
        {
            _elContexto = new Contexto();
        }
        public ProveedoresTabla Obtener(int IdProveedor)
        {
            ProveedoresTabla elProveedorEnBD = _elContexto.ProveedoresTabla.Where(elProveedor => elProveedor.IdProveedor == IdProveedor).FirstOrDefault();
            return elProveedorEnBD;
        }
    }
}