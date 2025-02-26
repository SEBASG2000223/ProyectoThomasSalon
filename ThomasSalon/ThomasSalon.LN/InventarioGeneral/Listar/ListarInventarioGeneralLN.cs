using System.Collections.Generic;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioGeneral;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioGeneral;
using ThomasSalon.Abstracciones.Modelos.InventarioGeneral;
using ThomasSalon.AccesoADatos.InventarioGeneral.Listar;

namespace ThomasSalon.LN.InventarioGeneral.Listar
{
    public class ListarInventarioGeneralLN : IInventarioGeneralLN
    {

        IInventarioGeneralAD _listarInventarioGeneralAD;

        public ListarInventarioGeneralLN()
        {
            _listarInventarioGeneralAD = new ListarInventarioGeneralAD();
        }
        public List<InventarioGeneralDto> Listar()
        {
            List<InventarioGeneralDto> laListaDeInventario = _listarInventarioGeneralAD.Listar();
            return laListaDeInventario;
        }
    }
}
