using System;
using System.Collections.Generic;
using ThomasSalon.Abstracciones.Modelos.Citas;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Citas.ObtenerPorId
{
    public interface IObtenerCitaPorIdLN
    {
        List<CitasDto> DetallesCita(Guid IdCita);
    }
}
