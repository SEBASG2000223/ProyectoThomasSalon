using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas.CambiarEstado
{
    public interface ICambiarEstadoCitaAD
    {
        Task<int> CambiarEstado(Guid IdCita, string nombreEstado);
    }
}
