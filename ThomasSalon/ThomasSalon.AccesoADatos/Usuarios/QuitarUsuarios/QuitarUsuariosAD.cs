using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.QuitarUsuarios;

namespace ThomasSalon.AccesoADatos.Usuarios.QuitarUsuarios
{
    public class QuitarUsuariosAD : IQuitarUsuariosAD
    {
        private readonly Contexto _elContexto;

        public QuitarUsuariosAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> EliminarUsuario(int IdUsuario)
        {
            var usuario = await _elContexto.UsuariosTabla
                .FirstOrDefaultAsync(elUsuario => elUsuario.IdPersona == IdUsuario);

            if (usuario != null)
            {
                _elContexto.UsuariosTabla.Remove(usuario);
                await _elContexto.SaveChangesAsync();
                return 1; 
            }

            return 2; 
        }
    }
}
