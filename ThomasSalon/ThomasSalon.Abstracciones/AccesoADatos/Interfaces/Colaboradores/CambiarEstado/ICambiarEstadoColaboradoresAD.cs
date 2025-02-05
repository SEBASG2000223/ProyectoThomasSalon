using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.CambiarEstado
{
    public interface ICambiarEstadoColaboradoresAD
    {
        Task<int> CambiarEstado(int IdColaborador, int nuevoEstado);
    }
}
