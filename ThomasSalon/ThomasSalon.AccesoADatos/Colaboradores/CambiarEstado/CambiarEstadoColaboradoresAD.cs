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
            var colaborador = await _elContexto.ColaboradoresTabla
                .FirstOrDefaultAsync(c => c.IdColaborador == IdColaborador);

            if (colaborador != null)
            {
                colaborador.IdEstado = nuevoEstado;
                _elContexto.Entry(colaborador).State = EntityState.Modified;
                await _elContexto.SaveChangesAsync();
                return 1;
            }
            return 2;
        }
    }
}