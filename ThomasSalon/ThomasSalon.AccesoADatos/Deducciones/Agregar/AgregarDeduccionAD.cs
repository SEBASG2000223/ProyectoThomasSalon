using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Deducciones.Agendar;
using ThomasSalon.Abstracciones.Modelos.Deducciones;

namespace ThomasSalon.AccesoADatos.Deducciones.Agregar
{

    public class AgregarDeduccionAD : IAgregarDeduccion
    {
        Contexto _elContexto;

        public AgregarDeduccionAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> AgregarDeduccionConDetalle(DeduccionesDto deduccion)
        {
            try
            {
                // Parámetros para el procedimiento almacenado
                var idColaboradorParam = new SqlParameter("@IdColaborador", SqlDbType.Int) { Value = deduccion.IdColaborador };
                var montoAgregadoParam = new SqlParameter("@MontoAgregado", SqlDbType.Decimal) { Value = deduccion.MontoAgregado };
                var descripcionParam = new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = deduccion.Descripcion };

                // Ejecutamos el procedimiento almacenado
                var resultado = await _elContexto.Database.ExecuteSqlCommandAsync(
                    "EXEC AgregarCuentaDeduccion @IdColaborador, @MontoAgregado, @Descripcion",
                    idColaboradorParam, montoAgregadoParam, descripcionParam
                );

                return resultado;
            }
            catch (SqlException ex)
            {
                // Manejo de excepción
                throw new InvalidOperationException("Hubo un error al agregar la deducción y su detalle.", ex);
            }


        }
    }
}
