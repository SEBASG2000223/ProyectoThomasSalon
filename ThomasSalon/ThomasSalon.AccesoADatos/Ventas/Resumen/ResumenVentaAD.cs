using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Ventas.Resumen;
using ThomasSalon.Abstracciones.Modelos.Ventas.Resumen;

namespace ThomasSalon.AccesoADatos.Ventas.Resumen
{
    public class ResumenVentaAD : IResumenVentaAD
    {
        Contexto _elContexto;

        public ResumenVentaAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<List<ResumenVentasDTO>> Listar()
        {
            var lista = new List<ResumenVentasDTO>();

            try
            {
                var conexion = _elContexto.Database.Connection;

                using (var comando = conexion.CreateCommand())
                {
                    comando.CommandText = "sp_ResumenVentas";
                    comando.CommandType = CommandType.StoredProcedure;

                    if (conexion.State != ConnectionState.Open)
                        await conexion.OpenAsync();

                    using (var reader = await comando.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var item = new ResumenVentasDTO
                            {
                                IdVenta = reader.GetGuid(reader.GetOrdinal("IdVenta")),
                                Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                                MontoTotal = reader.GetDecimal(reader.GetOrdinal("MontoTotal")),
                                NombreCliente = reader.GetString(reader.GetOrdinal("NombreCliente")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                Identificacion = reader.GetString(reader.GetOrdinal("Identificacion")),
                                NombreColaborador = reader.GetString(reader.GetOrdinal("NombreColaborador")),
                                MetodoPago = reader.GetString(reader.GetOrdinal("MetodoPago")),
                                NombreSucursal = reader.GetString(reader.GetOrdinal("NombreSucursal")),
                                MontoTotalDia = reader.GetDecimal(reader.GetOrdinal("MontoTotalDia")),
                                MontoTotalTransferencias = reader.GetDecimal(reader.GetOrdinal("MontoTotalTransferencias")),
                                MontoTotalSinpe = reader.GetDecimal(reader.GetOrdinal("MontoTotalSinpe")),
                                MontoTotalTarjeta = reader.GetDecimal(reader.GetOrdinal("MontoTotalTarjeta")),
                                MontoTotalEfectivo = reader.GetDecimal(reader.GetOrdinal("MontoTotalEfectivo")),
                                MontoTotalGastos = reader.GetDecimal(reader.GetOrdinal("MontoTotalGastos"))
                            };

                            lista.Add(item);
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener el resumen de ventas.", ex);
            }
        }
    }
}
