using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Servicios.CambiarEstado;

namespace ThomasSalon.AccesoADatos.Servicios.CambiarEstado
{
    public class CambiarEstadoServiciosAD : ICambiarEstadoServiciosAD
    {
        Contexto _elContexto;

        public CambiarEstadoServiciosAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> CambiarEstado(int IdServicio, int nuevoEstado)
        {
            var servicio = await _elContexto.ServiciosTabla
                .FirstOrDefaultAsync(s => s.IdServicio == IdServicio);

            if (servicio != null)
            {
                servicio.IdEstado = nuevoEstado;
                _elContexto.Entry(servicio).State = EntityState.Modified;
                await _elContexto.SaveChangesAsync();
                return 1; 
            }

            return 2; 
        }
    }
}