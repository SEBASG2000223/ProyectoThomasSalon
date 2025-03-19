using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Citas;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas.ObtenerPorId
{
    public interface IObtenerCitaPorIdAD
    {
        List<CitasDto> DetallesCita(Guid IdCita);
    }
}
