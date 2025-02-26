using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.QuitarUsuarios
{
    public interface IQuitarUsuariosAD
    {
        Task<int> EliminarUsuario(int IdUsuario);
    }
}
