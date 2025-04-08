using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas.CambiarEstado;

namespace ThomasSalon.AccesoADatos.Citas.CambiarEstado
{
    public class CambiarEstadoCitaAD : ICambiarEstadoCitaAD
    {
        Contexto _elContexto;


        public CambiarEstadoCitaAD()
        {
            _elContexto = new Contexto();

        }

        public async Task<int> CambiarEstado(Guid IdCita, string nombreEstado)
        {
            var cita = await _elContexto.CitasTabla
                .FirstOrDefaultAsync(laCita => laCita.IdCita == IdCita);

            if (cita != null)
            {
                // Buscar el ID del estado basado en el nombre
                var estado = await _elContexto.EstadoCitaTabla
                    .Where(e => e.Nombre == nombreEstado)
                    .Select(e => e.IdEstadoCita)
                    .FirstOrDefaultAsync();

                if (estado == Guid.Empty)
                {
                    return 3; 
                }
                cita.IdEstadoCita = estado;
                _elContexto.Entry(cita).State = EntityState.Modified;
                await _elContexto.SaveChangesAsync();
                return 1;
            }
            return 2;
        }

    }
}
