using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas.Agendar;
using ThomasSalon.Abstracciones.Modelos.Citas;

namespace ThomasSalon.AccesoADatos.Citas.Agendar
{
    public class AgendarCitasAD : IAgendarCitasAD
    {
        private readonly Contexto _elContexto;

        public AgendarCitasAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> AgendarCitaPresencial(CitasDto modelo, int idSucursal)
        {
            try
            {
                // Obtener la duración del servicio
                var duracionServicio = await ObtenerDuracionServicio(modelo.IdServicio);

                // Verificar que la hora de finalización no se pase de las 7:00 PM
                var horaFin = modelo.FechaHora.AddMinutes(duracionServicio);
                if (horaFin.Hour >= 19 || (horaFin.Hour == 18 && horaFin.Minute > 30))
                {
                    throw new InvalidOperationException("La duración del servicio excede el horario permitido (hasta las 7:00 PM).");
                }

                // Validación de horarios en los domingos
                if (modelo.FechaHora.DayOfWeek == DayOfWeek.Sunday && horaFin.Hour >= 15 && horaFin.Minute > 30)
                {
                    throw new InvalidOperationException("Las citas los domingos no pueden ser después de las 3:30 PM.");
                }

                // Validar el horario de la primera cita
                if (modelo.FechaHora.Hour == 9 && modelo.FechaHora.Minute != 30)
                {
                    throw new InvalidOperationException("La primera cita debe ser a las 9:30 AM.");
                }


                // Crear los parámetros para el procedimiento almacenado
                var idServicioParam = new SqlParameter("@IdServicio", SqlDbType.Int) { Value = modelo.IdServicio };
                var idSucursalParam = new SqlParameter("@IdSucursal", SqlDbType.Int) { Value = idSucursal }; // Usar idSucursal
                var idColaboradorParam = new SqlParameter("@IdColaborador", SqlDbType.Int) { Value = (object)modelo.IdColaborador ?? DBNull.Value };
                var identificacionParam = new SqlParameter("@Identificacion", SqlDbType.NVarChar, 50) { Value = modelo.Identificacion };
                var fechaHoraParam = new SqlParameter("@FechaHora", SqlDbType.DateTime) { Value = modelo.FechaHora };
                var comentarioParam = new SqlParameter("@Comentario", SqlDbType.VarChar, 100) { Value = (object)modelo.Comentario ?? DBNull.Value };

                // Ejecutar el procedimiento almacenado
                var resultado = await _elContexto.Database.ExecuteSqlCommandAsync(
                    "EXEC SP_InsertarCitaPresencial @IdServicio, @IdSucursal, @IdColaborador, @Identificacion, @FechaHora, @Comentario",
                    idServicioParam, idSucursalParam, idColaboradorParam, identificacionParam, fechaHoraParam, comentarioParam
                );

                return resultado;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"Error al agendar la cita: {ex.Message}");
            }
        }


        public async Task<int> AgendarCitaLinea(CitasDto modelo, string idUsuario)
        {
            try
            {
                // Obtener la duración del servicio
                var duracionServicio = await ObtenerDuracionServicio(modelo.IdServicio);

                // Verificar que la hora de finalización no se pase de las 7:00 PM
                var horaFin = modelo.FechaHora.AddMinutes(duracionServicio);
                if (horaFin.Hour >= 19 || (horaFin.Hour == 18 && horaFin.Minute > 30))
                {
                    throw new InvalidOperationException("La duración del servicio excede el horario permitido (hasta las 7:00 PM).");
                }

                // Validación de horarios en los domingos
                if (modelo.FechaHora.DayOfWeek == DayOfWeek.Sunday && horaFin.Hour >= 15 && horaFin.Minute > 30)
                {
                    throw new InvalidOperationException("Las citas los domingos no pueden ser después de las 3:30 PM.");
                }

                // Validar el horario de la primera cita
                if (modelo.FechaHora.Hour == 9 && modelo.FechaHora.Minute != 30)
                {
                    throw new InvalidOperationException("La primera cita debe ser a las 9:30 AM.");
                }
          

                // Crear los parámetros para el procedimiento almacenado
                var idServicioParam = new SqlParameter("@IdServicio", SqlDbType.Int) { Value = modelo.IdServicio };
                var idSucursalParam = new SqlParameter("@IdSucursal", SqlDbType.Int) { Value = modelo.IdSucursal }; // Usar idSucursal
                var idColaboradorParam = new SqlParameter("@IdColaborador", SqlDbType.Int) { Value = (object)modelo.IdColaborador ?? DBNull.Value };
                var idUsuarioParam = new SqlParameter("@IdUsuario", SqlDbType.NVarChar, 50) { Value = idUsuario };
                var fechaHoraParam = new SqlParameter("@FechaHora", SqlDbType.DateTime) { Value = modelo.FechaHora };
                var comentarioParam = new SqlParameter("@Comentario", SqlDbType.VarChar, 100) { Value = (object)modelo.Comentario ?? DBNull.Value };

                // Ejecutar el procedimiento almacenado
                var resultado = await _elContexto.Database.ExecuteSqlCommandAsync(
                    "EXEC SP_InsertarCitaEnLinea @IdServicio, @IdSucursal, @IdColaborador, @IdUsuario, @FechaHora, @Comentario",
                    idServicioParam, idSucursalParam, idColaboradorParam, idUsuarioParam, fechaHoraParam, comentarioParam
                );

                return resultado;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException($"Error al agendar la cita: {ex.Message}");
            }
        }



        private async Task<int> ObtenerDuracionServicio(int idServicio)
        {
            try
            {
                var duracion = await _elContexto.ServiciosTabla
                                                 .Where(s => s.IdServicio == idServicio)
                                                 .Select(s => s.Duracion)
                                                 .FirstOrDefaultAsync();

                if (duracion == null)
                {
                    throw new InvalidOperationException("El servicio no tiene una duración definida.");
                }

                int duracionEnMinutos = (int)duracion.TotalMinutes;

                return duracionEnMinutos;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener la duración del servicio: {ex.Message}");
            }
        }




    }
}
