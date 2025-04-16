using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas.Agendar;
using ThomasSalon.Abstracciones.LN.Interfaces.Citas.Agendar;
using ThomasSalon.Abstracciones.Modelos.Citas;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos;
using ThomasSalon.AccesoADatos.Citas.Agendar;

namespace ThomasSalon.LN.Citas.Agendar
{
    public class AgendarCitasLN : IAgendarCitasLN
    {
        IAgendarCitasAD _agendarCitasAD;
        Contexto _elContexto;

        public AgendarCitasLN()
        {
            _agendarCitasAD = new AgendarCitasAD();
            _elContexto = new Contexto();
        }
        public async Task<int> AgendarCitaPresencial(CitasDto cita, int idSucursal)
        {
            try
            {
                int cantidadDeDatosGuardados = await _agendarCitasAD.AgendarCitaPresencial(cita, idSucursal);
                return cantidadDeDatosGuardados;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("No se pudo agendar la cita: " + ex.Message);
            }
        }

        public async Task<int> AgendarCitaLinea(CitasDto cita, string idUsuario)
        {
            try
            {
                int cantidadDeDatosGuardados = await _agendarCitasAD.AgendarCitaLinea(cita, idUsuario);
                return cantidadDeDatosGuardados;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("No se pudo agendar la cita: " + ex.Message);
            }
        }
        public List<string> ObtenerHorariosDisponibles(int idServicio, int idSucursal)
        {
            List<string> horariosDisponibles = new List<string>();

            // Obtener el tipo de servicio del idServicio actual
            var tipoServicio = _elContexto.ServiciosTabla
                .Where(s => s.IdServicio == idServicio)
                .Select(s => s.IdTipoServicios)  // o s.TipoServicioId
                .FirstOrDefault();

            // Rango de disponibilidad
            DateTime inicioDia = DateTime.Today.AddHours(9).AddMinutes(30); // La primera cita es a las 9:30 AM
            DateTime finDia = DateTime.Today.AddHours(19); // Hasta las 7:00 PM

            for (DateTime hora = inicioDia; hora <= finDia; hora = hora.AddMinutes(30))
            {
                // Si es domingo, la disponibilidad termina a las 3:30 PM
                if (hora.DayOfWeek == DayOfWeek.Sunday && hora.Hour >= 15 && hora.Minute > 30)
                    break;

                // Obtener todos los IdServicios que sean del mismo tipo
                var serviciosDelMismoTipo = _elContexto.ServiciosTabla
                    .Where(s => s.IdTipoServicios == tipoServicio)
                    .Select(s => s.IdServicio)
                    .ToList();

                // Contar las citas que tengan uno de esos servicios, a esa hora y sucursal
                int cantidadCitasMismoTipo = _elContexto.CitasTabla
                    .Where(c => serviciosDelMismoTipo.Contains(c.IdServicio)
                                && c.FechaHora == hora
                                && c.IdSucursal == idSucursal)
                    .Count();

                if (cantidadCitasMismoTipo < 2)
                {
                    horariosDisponibles.Add(hora.ToString("yyyy-MM-dd HH:mm"));
                }
            }

            return horariosDisponibles;
        }





        private CitasTabla ConvertirObjetoAProductosTabla(CitasDto laCita)
        {
            return new CitasTabla
            {
                IdCita = laCita.IdCita,
                IdColaborador = laCita.IdColaborador,
                IdEstadoCita = laCita.IdEstadoCita,
                IdPersona = laCita.IdPersona,
                IdServicio = laCita.IdServicio,
                IdSucursal = laCita.IdSucursal,
                FechaHora = laCita.FechaHora,
                Comentario = laCita.Comentario


            };
        }
    }
}
