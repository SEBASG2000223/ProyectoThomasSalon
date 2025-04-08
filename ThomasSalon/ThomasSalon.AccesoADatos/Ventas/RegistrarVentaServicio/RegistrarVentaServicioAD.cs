using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Ventas.RegistrarVentaServicio;
using ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaServicio;

namespace ThomasSalon.AccesoADatos.Ventas.RegistrarVentaServicio
{
    public class RegistrarVentaServicioAD : IRegistrarVentaServicioAD
    {
        Contexto _elContexto;
        public RegistrarVentaServicioAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> RegistrarVentaServicio(RegistrarVentaServicioDTO ventaServicio)
        {
            try
            {
                var paramColaborador = new SqlParameter("@IdColaborador", SqlDbType.Int) { Value = ventaServicio.IdColaborador };
                var paramMetodoPago = new SqlParameter("@IdMetodoPago", SqlDbType.UniqueIdentifier) { Value = ventaServicio.IdMetodoPago };
                var paramPersona = new SqlParameter("@IdPersona", SqlDbType.Int) { Value = ventaServicio.IdPersona };
                var paramSucursal = new SqlParameter("@IdSucursal", SqlDbType.Int) { Value = ventaServicio.IdSucursal };

                // Crear el DataTable que representa Tipo_ServicioVenta
                var table = new DataTable();
                table.Columns.Add("IdServicio", typeof(int));
                table.Columns.Add("Precio", typeof(decimal));

                foreach (var s in ventaServicio.Servicios)
                {
                    table.Rows.Add(s.IdServicio, s.Precio);
                }

                var paramServicios = new SqlParameter("@Servicios", SqlDbType.Structured)
                {
                    TypeName = "Tipo_ServicioVenta", // Debe coincidir con el tipo definido en SQL Server
                    Value = table
                };

                var resultado = await _elContexto.Database.ExecuteSqlCommandAsync(
                    "EXEC sp_RegistrarVentaServicioss @IdColaborador, @IdMetodoPago, @IdPersona, @IdSucursal, @Servicios",
                    paramColaborador, paramMetodoPago, paramPersona, paramSucursal, paramServicios
                );

                return resultado;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al registrar la venta del servicio.", ex);
            }
        }

    }
}
    
