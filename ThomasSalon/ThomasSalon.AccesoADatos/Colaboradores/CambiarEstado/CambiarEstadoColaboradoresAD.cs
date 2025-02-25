using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.CambiarEstado;

namespace ThomasSalon.AccesoADatos.Colaboradores.CambiarEstado
{
    public class CambiarEstadoColaboradoresAD : ICambiarEstadoColaboradoresAD
    {
        Contexto _elContexto;

        public CambiarEstadoColaboradoresAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> CambiarEstado(int IdColaborador, int nuevoEstado)
        {
            // Buscar el colaborador usando el IdColaborador para obtener su IdPersona
            var colaborador = await _elContexto.ColaboradoresTabla
                .FirstOrDefaultAsync(c => c.IdColaborador == IdColaborador);

            // Buscar el usuario usando el IdPersona del colaborador
            var usuario = await _elContexto.UsuariosTabla
                .FirstOrDefaultAsync(u => u.IdPersona == colaborador.IdPersona);

            bool cambiosRealizados = false;

            // Si el colaborador existe, actualizar su estado
            if (colaborador != null)
            {
                colaborador.IdEstado = nuevoEstado;
                _elContexto.Entry(colaborador).State = EntityState.Modified;
                cambiosRealizados = true;
            }

            // Si el usuario existe, actualizar su estado
            if (usuario != null)
            {
                usuario.IdEstado = nuevoEstado;
                _elContexto.Entry(usuario).State = EntityState.Modified;
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