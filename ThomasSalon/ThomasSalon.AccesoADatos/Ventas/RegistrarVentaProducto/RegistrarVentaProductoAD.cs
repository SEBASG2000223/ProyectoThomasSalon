using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaProducto;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Ventas.RegistrarVentaProducto;

namespace ThomasSalon.AccesoADatos.Ventas.RegistrarVentaProducto
{
    public class RegistrarVentaProductoAD : IRegistrarVentaProductoAD
    {
        private Contexto _elContexto;

        public RegistrarVentaProductoAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> RegistrarVentaProducto(RegistrarVentaProductoDTO ventaProducto)
        {
            try
            {
                var paramColaborador = new SqlParameter("@IdColaborador", SqlDbType.Int) { Value = ventaProducto.IdColaborador };
                var paramMetodoPago = new SqlParameter("@IdMetodoPago", SqlDbType.UniqueIdentifier) { Value = ventaProducto.IdMetodoPago };
                var paramPersona = new SqlParameter("@IdPersona", SqlDbType.Int) { Value = ventaProducto.IdPersona };
                var paramSucursal = new SqlParameter("@IdSucursal", SqlDbType.Int) { Value = ventaProducto.IdSucursal };

                // Crear el DataTable que representa Tipo_ProductoVenta
                var table = new DataTable();
                table.Columns.Add("IdProducto", typeof(int));
                table.Columns.Add("Cantidad", typeof(int));
                table.Columns.Add("PrecioUnitario", typeof(decimal));

                foreach (var p in ventaProducto.Productos)
                {
                    table.Rows.Add(p.IdProducto, p.Cantidad, p.PrecioUnitario);
                }

                var paramProductos = new SqlParameter("@Productos", SqlDbType.Structured)
                {
                    TypeName = "Tipo_ProductoVenta", // debe coincidir con el tipo definido en SQL Server
                    Value = table
                };

                var resultado = await _elContexto.Database.ExecuteSqlCommandAsync(
                    "EXEC sp_RegistrarVentaProductos @IdColaborador, @IdMetodoPago, @IdPersona, @IdSucursal, @Productos",
                    paramColaborador, paramMetodoPago, paramPersona, paramSucursal, paramProductos
                );

                return resultado;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al registrar la venta del producto.", ex);
            }
        }
    }
}    
