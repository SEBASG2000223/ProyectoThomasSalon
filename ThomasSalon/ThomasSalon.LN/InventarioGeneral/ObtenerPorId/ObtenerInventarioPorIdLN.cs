using System;
using System.Collections.Generic;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioGeneral.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioGeneral.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.InventarioGeneral;
using ThomasSalon.AccesoADatos.InventarioGeneral.ObtenerPorId;

namespace ThomasSalon.LN.InventarioGeneral.ObtenerPorId
{
    public class ObtenerInventarioPorIdLN : IObtenerInventarioPorIdLN
    {
        IObtenerInventarioPorIdAD _obtenerInventarioGeneralAD;

        public ObtenerInventarioPorIdLN()
        {
            _obtenerInventarioGeneralAD = new ObtenerInventarioPorIdAD();
        }
        public List<InventarioGeneralDto> DetallesInventario(Guid IdInventarioGeneral)
        {

            List<InventarioGeneralDto> laListaInventario = _obtenerInventarioGeneralAD.DetallesInventario(IdInventarioGeneral);
            return laListaInventario;
        }
    }
}
