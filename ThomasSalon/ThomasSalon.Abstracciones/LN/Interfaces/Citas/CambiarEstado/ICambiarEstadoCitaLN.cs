using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Citas.CambiarEstado
{
    public interface ICambiarEstadoCitaLN
    {
        Task<int> CambiarEstado(Guid IdCita, string nombreEstado);
    }
}
