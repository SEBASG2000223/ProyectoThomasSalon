using System;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Citas.CambiarEstado;
using ThomasSalon.AccesoADatos.Citas.CambiarEstado;

namespace ThomasSalon.LN.Citas.CambiarEstado
{
    public class CambiarEstadoCitaLN : ICambiarEstadoCitaLN
    {
        ICambiarEstadoCitaAD _cambiarEstado;

        public CambiarEstadoCitaLN()
        {
            _cambiarEstado = new CambiarEstadoCitaAD();
        }
        public async Task<int> CambiarEstado(Guid IdCita, string nombreEstado)
        {
            return await _cambiarEstado.CambiarEstado(IdCita, nombreEstado);
        }

    }
}
