using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Pagos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Pagos
{
    public interface IListarPagosAD
    {
        Task<List<PagosDto>> GenerarPago(int idColaborador);
        Task ConfirmarPago(int idColaborador);


    }
}
