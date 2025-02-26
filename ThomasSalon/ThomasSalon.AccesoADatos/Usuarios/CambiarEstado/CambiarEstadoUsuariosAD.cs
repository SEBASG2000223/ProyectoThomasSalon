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
            // Buscar el usuario usando el IdUsuario
            var usuario = await _elContexto.UsuariosTabla
                .FirstOrDefaultAsync(elUsuario => elUsuario.Id == IdUsuario);

            // Buscar el colaborador usando el IdPersona del usuario
            var colaborador = await _elContexto.ColaboradoresTabla
                .FirstOrDefaultAsync(c => c.IdPersona == usuario.IdPersona);

            bool cambiosRealizados = false;

            // Si el usuario existe, actualizar su estado
            if (usuario != null)
            {
                usuario.IdEstado = nuevoEstado;
                _elContexto.Entry(usuario).State = EntityState.Modified;
                cambiosRealizados = true;
            }

            // Si el colaborador existe, actualizar su estado
            if (colaborador != null)
            {
                colaborador.IdEstado = nuevoEstado;
                _elContexto.Entry(colaborador).State = EntityState.Modified;
                cambiosRealizados = true;
            }

            // Si se realizaron cambios, guardar
            if (cambiosRealizados)
            {
                await _elContexto.SaveChangesAsync();
                return 1; // Operación exitosa
            }

            return 2; // Si no se encuentran ni colaborador ni usuario
        }


    }
}
