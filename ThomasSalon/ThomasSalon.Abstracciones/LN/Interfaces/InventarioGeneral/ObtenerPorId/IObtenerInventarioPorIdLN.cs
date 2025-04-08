using System;
using System.Collections.Generic;
using ThomasSalon.Abstracciones.Modelos.InventarioGeneral;

namespace ThomasSalon.Abstracciones.LN.Interfaces.InventarioGeneral.ObtenerPorId
{
    public interface IObtenerInventarioPorIdLN
    {
        List<InventarioGeneralDto> DetallesInventario(Guid IdInventarioGeneral);
    }
}
