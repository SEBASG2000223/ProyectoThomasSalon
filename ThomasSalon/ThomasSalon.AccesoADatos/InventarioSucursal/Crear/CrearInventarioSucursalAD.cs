using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioSucursal.Crear;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.InventarioSucursal.Crear
{
    public class CrearInventarioSucursalAD : ICrearInventarioSucursalAD
    {
        Contexto _elContexto;

        public CrearInventarioSucursalAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Agregar(InventarioSucursalTabla elInventarioAGuardar)
        {
            try
            {
                var idSucursalParam = new SqlParameter("@IdSucursal", SqlDbType.Int) { Value = elInventarioAGuardar.IdSucursal };
                var idProductoParam = new SqlParameter("@IdProducto", SqlDbType.Int) { Value = elInventarioAGuardar.IdProducto };
                var cantidadParam = new SqlParameter("@Cantidad", SqlDbType.Int) { Value = elInventarioAGuardar.Cantidad };

                var resultado = await _elContexto.Database.ExecuteSqlCommandAsync(
                    "EXEC SP_InsertarInventarioSucursalGerente @IdSucursal, @IdProducto, @Cantidad",
                    idSucursalParam, idProductoParam, cantidadParam
                );

                return resultado; 
            }
            catch (Exception ex)
            {
               
               
                return 0;
            }
        }
    }
}
