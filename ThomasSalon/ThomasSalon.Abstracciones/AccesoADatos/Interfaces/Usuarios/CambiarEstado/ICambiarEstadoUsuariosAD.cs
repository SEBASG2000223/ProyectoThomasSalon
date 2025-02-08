using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.CambiarEstado
{
    public interface ICambiarEstadoUsuariosAD
    {
        Task<int> CambiarEstado(string IdUsuario, int nuevoEstado);

    }
}
