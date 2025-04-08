using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Pagos;
using ThomasSalon.Abstracciones.Modelos.Pagos;

namespace ThomasSalon.AccesoADatos.Pagos
{
    public class ListarPagosAD : IListarPagosAD
    {
        Contexto _elContexto;

        public ListarPagosAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<List<PagosDto>> GenerarPago(int idColaborador)
        {
            try
            {
                // Definir el parámetro que el procedimiento almacenado necesita
                var idColaboradorParam = new SqlParameter("@IdColaborador", SqlDbType.Int) { Value = idColaborador };

                // Ejecutar el procedimiento almacenado para generar el pago temporal
                var resultado = await _elContexto.Database.SqlQuery<PagosDto>(
                    "EXEC GENERAR_PAGO_TEMPORAL_SP @IdColaborador", idColaboradorParam
                ).ToListAsync();

                // Si no hay resultados, lanzar una excepción o retornar un resultado vacío
                if (resultado == null || resultado.Count == 0)
                {
                    throw new InvalidOperationException("No se encontraron registros de pago temporal.");
                }


                // Retornar los resultados obtenidos del pago temporal
                return resultado;
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("Hubo un error al generar el pago.", ex);
            }
        }

        public async Task ConfirmarPago(int idColaborador)
        {
            try
            {
                // Definir el parámetro para el procedimiento almacenado de confirmación
                var idColaboradorParam = new SqlParameter("@IdColaborador", SqlDbType.Int) { Value = idColaborador };

                // Ejecutar el procedimiento almacenado para confirmar el pago
                await _elContexto.Database.ExecuteSqlCommandAsync(
                    "EXEC CONFIRMAR_PAGO_SP @IdColaborador", idColaboradorParam
                );
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("Hubo un error al confirmar el pago.", ex);
            }
        }



    }
}
