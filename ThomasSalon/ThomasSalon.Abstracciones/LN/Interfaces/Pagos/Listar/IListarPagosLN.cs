using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Pagos;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Pagos.Listar
{
    public interface IListarPagosLN
    {
        Task<List<PagosDto>> ListarPagos(int idColaborador);
        Task ConfirmarPago(int idColaborador);
    }
}
