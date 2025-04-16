using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.AsistenciaColaboradores.AgregarAsistencia;
using ThomasSalon.Abstracciones.Modelos.AsistenciaColaboradores.AgregarAsistencia;

namespace ThomasSalon.AccesoADatos.AsistenciaColaboradores.AgregarAsistencia
{
    public class AgregarAsistenciaAD : IAgregarAsistenciaAD
    {
        Contexto _elContexto;
        public AgregarAsistenciaAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> AgregarAsistencia(AsistenciaColaboradorDTO asistencia)
        {
            try
            {
                var paramColaborador = new SqlParameter("@IdColaborador", SqlDbType.Int) { Value = asistencia.IdColaborador };
                var paramTipoJornada = new SqlParameter("@IdTipoJornada", SqlDbType.Int) { Value = asistencia.IdTipoJornada };
                var paramSucursal = new SqlParameter("@IdSucursal", SqlDbType.Int) { Value = asistencia.IdSucursal };
                var paramFecha = new SqlParameter("@Fecha", SqlDbType.DateTime)
                {
                    Value = asistencia.Fecha ?? (object)DBNull.Value
                };

                var resultado = await _elContexto.Database.ExecuteSqlCommandAsync(
                    "EXEC InsertarAsistenciaColaborador @IdColaborador, @IdTipoJornada, @IdSucursal, @Fecha",
                    paramColaborador, paramTipoJornada, paramSucursal, paramFecha
                );

                return resultado;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al registrar la asistencia del colaborador.", ex);
            }
        }

    }
}
