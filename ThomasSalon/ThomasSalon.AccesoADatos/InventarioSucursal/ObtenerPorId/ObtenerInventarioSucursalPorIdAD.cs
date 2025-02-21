using System;
using System.Linq;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioSucursal.ObtenerPorId;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.InventarioSucursal.ObtenerPorId
{
    public class ObtenerInventarioSucursalPorIdAD : IObtenerInventarioSucursalPorIdAD
    {
        Contexto _elContexto;

        public ObtenerInventarioSucursalPorIdAD()
        {
            _elContexto = new Contexto();
        }
        public InventarioSucursalTabla Obtener(int idProducto)
        {
            InventarioSucursalTabla elInventarioEnTabla = _elContexto.InventarioSucursalTabla.Where(elInventaio => elInventaio.IdProducto == idProducto).FirstOrDefault();
            return elInventarioEnTabla;
        }
    }
}
