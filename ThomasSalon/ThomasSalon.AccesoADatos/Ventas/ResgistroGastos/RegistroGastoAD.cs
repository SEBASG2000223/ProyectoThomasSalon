using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Ventas.ResgistroGastos;
using ThomasSalon.Abstracciones.Modelos.Ventas.ResgistroGastos;

namespace ThomasSalon.AccesoADatos.Ventas.ResgistroGastos
{
    public class RegistroGastoAD : IRegistroGastoAD
    {
        Contexto _elContexto;

        public RegistroGastoAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> RegistroGasto(RegistroGastoDTO registroGasto)
        {
            try
            {
                var paramColaborador = new SqlParameter("@IdColaborador", SqlDbType.Int) { Value = registroGasto.IdColaborador };
                var paramSucursal = new SqlParameter("@IdSucursal", SqlDbType.Int) { Value = registroGasto.IdSucursal };
                var paramDescripcion = new SqlParameter("@Descripcion", SqlDbType.VarChar, 100)
                {
                    Value = registroGasto.Descripcion ?? (object)DBNull.Value
                };
                var paramMonto = new SqlParameter("@Monto", SqlDbType.Decimal)
                {
                    Precision = 10,
                    Scale = 2,
                    Value = registroGasto.Monto
                };

                var resultado = await _elContexto.Database.ExecuteSqlCommandAsync(
                    "EXEC sp_RegistrarGasto @IdColaborador, @IdSucursal, @Descripcion, @Monto",
                    paramColaborador, paramSucursal, paramDescripcion, paramMonto
                );

                return resultado;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al registrar el gasto.", ex);
            }
        }
    }
}
