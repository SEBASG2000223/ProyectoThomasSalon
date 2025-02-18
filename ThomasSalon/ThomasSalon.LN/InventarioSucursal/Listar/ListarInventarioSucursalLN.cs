using System.Collections.Generic;
using ThomasSalon.Abstracciones.AccesoADatos.InventarioSucursal;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.AccesoADatos.InventarioSucursal.Listar;

namespace ThomasSalon.LN.InventarioSucursal.Listar
{
    public class ListarInventarioSucursalLN : IListarInventarioSucursalLN
    {
        IListarInventarioSucursalAD _listarInventarioSucursalAD;

        public ListarInventarioSucursalLN()
        {
            _listarInventarioSucursalAD = new ListarInventarioSucursalAD();
        }
        public List<InventarioSucursalDto> Listar(int idSucursal)
        {
            List<InventarioSucursalDto> laListaDeInventario = _listarInventarioSucursalAD.Listar(idSucursal);
            return laListaDeInventario;
        }
    }
}
