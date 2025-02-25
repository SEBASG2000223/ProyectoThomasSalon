using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.CambiarEstado;
using System.Data.Entity;

namespace ThomasSalon.AccesoADatos.Usuarios.CambiarEstado
{
    public class CambiarEstadoUsuariosAD : ICambiarEstadoUsuariosAD
    {
        Contexto _elContexto;


        public CambiarEstadoUsuariosAD()
        {
            _elContexto = new Contexto();

        }
        public async Task<int> CambiarEstado(string IdUsuario, int nuevoEstado)
        {
            var usuario = await _elContexto.UsuariosTabla
               .FirstOrDefaultAsync(elUsuario => elUsuario.Id == IdUsuario.ToString());

            if (usuario != null)
            {
                usuario.IdEstado = nuevoEstado;

                _elContexto.Entry(usuario).State = EntityState.Modified;
                await _elContexto.SaveChangesAsync();
                return 1;
            }

            return 2;
        }
    }
}
