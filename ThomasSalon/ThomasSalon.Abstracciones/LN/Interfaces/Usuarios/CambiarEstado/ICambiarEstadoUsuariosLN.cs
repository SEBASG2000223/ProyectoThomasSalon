using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.CambiarEstado
{
    public interface ICambiarEstadoUsuariosLN
    {
        Task<int> CambiarEstado(string IdUsuario, int nuevoEstado);

    }
}
