using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.QuitarUsuarios;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.QuitarUsuarios;
using ThomasSalon.AccesoADatos.Usuarios.QuitarUsuarios;

namespace ThomasSalon.LN.Usuarios.QuitarUsuarios
{
    public class QuitarUsuariosLN : IQuitarUsuariosLN
    {
        private readonly IQuitarUsuariosAD _quitarUsuarioAD;

        public QuitarUsuariosLN()
        {
            _quitarUsuarioAD = new QuitarUsuariosAD();
        }

        public async Task<int> EliminarUsuario(int IdUsuario)
        {
            return await _quitarUsuarioAD.EliminarUsuario(IdUsuario);
        }
    }
}
