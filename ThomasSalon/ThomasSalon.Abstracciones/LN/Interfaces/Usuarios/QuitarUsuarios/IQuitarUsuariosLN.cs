using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.QuitarUsuarios
{
    public interface IQuitarUsuariosLN
    {
        Task<int> EliminarUsuario(int IdUsuario);
    }
}
