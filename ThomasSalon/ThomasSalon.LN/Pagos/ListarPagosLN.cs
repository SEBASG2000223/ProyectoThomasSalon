using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Pagos;
using ThomasSalon.Abstracciones.LN.Interfaces.Pagos.Listar;
using ThomasSalon.Abstracciones.Modelos.Pagos;
using ThomasSalon.AccesoADatos.Pagos;

public class ListarPagosLN : IListarPagosLN
{
    private readonly IListarPagosAD _listarPagosAD;

    public ListarPagosLN()
    {
        _listarPagosAD = new ListarPagosAD();
    }

    public async Task<List<PagosDto>> ListarPagos(int idColaborador)
    {
        try
        {
            return await _listarPagosAD.GenerarPago(idColaborador);
        }
        catch (Exception ex)
        {
            throw new Exception("Hubo un error al listar los pagos.", ex);
        }
    }

    public async Task ConfirmarPago(int idColaborador)
    {
        try
        {
            await _listarPagosAD.ConfirmarPago(idColaborador);
        }
        catch (Exception ex)
        {
            throw new Exception("Hubo un error al confirmar el pago.", ex);
        }
    }
}
