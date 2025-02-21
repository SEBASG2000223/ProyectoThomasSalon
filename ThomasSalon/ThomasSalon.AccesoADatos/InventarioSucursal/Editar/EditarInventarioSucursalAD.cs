using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioSucursal.Editar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.InventarioSucursal.Editar
{
    public class EditarInventarioSucursalAD : IEditarInventarioSucursalAD
    {
        private readonly Contexto _elContexto;

        public EditarInventarioSucursalAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> EditarInventarioSucursal(InventarioSucursalTabla elInventarioAGuardar)
        {

            try
            {
                var idSucursalParam = new SqlParameter("@IdSucursal", SqlDbType.Int) { Value = elInventarioAGuardar.IdSucursal };
                var idProductoParam = new SqlParameter("@IdProducto", SqlDbType.Int) { Value = elInventarioAGuardar.IdProducto };
                var cantidadParam = new SqlParameter("@Cantidad", SqlDbType.Int) { Value = elInventarioAGuardar.Cantidad };

                var resultado = await _elContexto.Database.ExecuteSqlCommandAsync(
                        "EXEC SP_ActualizarInventarioSucursalGerente @IdSucursal, @IdProducto, @Cantidad",
                    idSucursalParam, idProductoParam, cantidadParam
                );

                return resultado;
            }
            catch (SqlException ex)
            {

                throw new InvalidOperationException("El producto no existe en la sucursal.");

            }
        }


    }
}
