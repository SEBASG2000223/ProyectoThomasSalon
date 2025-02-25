using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.CambiarEstado
{
    public interface ICambiarEstadoColaboradoresLN
    {
        Task<int> CambiarEstado(int IdColaborador, int nuevoEstado);
      
    }
}
