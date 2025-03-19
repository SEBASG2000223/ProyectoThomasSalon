using System;
using System.Collections.Generic;
using ThomasSalon.Abstracciones.Modelos.InventarioGeneral;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioGeneral.ObtenerPorId
{
    public interface IObtenerInventarioPorIdAD
    {
        List<InventarioGeneralDto> DetallesInventario(Guid IdInventarioGeneral);
    }
}
